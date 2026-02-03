using Logic_Challenger.Models;
using Mscc.GenerativeAI;
using Mscc.GenerativeAI.Types;
using System.Text.Json;

namespace Logic_Challenger.Services;

public class ChallengeGenService : IChallengeGenService
{
    private readonly string _apiKey;
    public ChallengeGenService(IConfiguration config)
    {
        _apiKey = config["GeminiKey"] ?? throw new Exception("Chave não encontrada");
    }

    public async Task<ChallengeViewModel> GenerateChallenge(int difficulty)
    {
        var googleAI = new GoogleAI(_apiKey);
        var systemInstruction =
            @"Você é um Mestre de Lógica Socrático.
            REGRAS:
            1. Seu objetivo é gerar desafios de raciocínio lógicos, pode escolher aleatoriamente entre um destes tipos:
               - Lógica Dedutiva (Silogismos, quem é quem)
               - Sequências e Padrões (Próximo número)
               - Pensamento Lateral (Charadas, 'pegadinhas' inteligentes)
               - Matemática Básica (Mas com truque lógico)
            2. Responda APENAS um JSON puro, sem markdown (```json), seguindo estritamente este modelo:
            {
                ""Question"": ""O texto do desafio aqui"",
                ""Answer"": ""A resposta correta aqui (curta)"",
            }
            3. Quando te exigerem o nivel de dificuldade em número inteiro, ele necessariamente deve ser um número de 1 (fácil) a 5 (muito difícil).";

        var genConfig = new GenerationConfig
        {
            Temperature = 0.9,
            TopK = 40
        };

        var model = googleAI.GenerativeModel
            (Model.Gemini3Flash, 
            generationConfig: genConfig,
            systemInstruction: new Content(systemInstruction));

        var response = await model.GenerateContent($"Gere um desafio lógico aleatório. Com o nível de dificuldade: {difficulty}");

        if (string.IsNullOrWhiteSpace(response.Text))
        {
            return new ChallengeViewModel { Question = "A IA não retornou nada. Tente de novo." };
        }

        var cleanJSON = response.Text.Replace("```json", "").Replace("```", "");

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        try
        {
            var challenge = JsonSerializer.Deserialize<ChallengeViewModel>(cleanJSON, options);
            challenge!.CreatedQuestion = true;
            challenge.Feedback = string.Empty;
            challenge.Difficulty = difficulty;
            return challenge ?? new ChallengeViewModel();
        }
        catch (JsonException)
        {
            return new ChallengeViewModel { Question = "Erro ao ler o formato da resposta da IA." };
        }
    }

    public async Task<string> CheckAnswer(string CorrectAnswer, string UserAnswer, string OriginalQuestion)
    {
        var googleAI = new GoogleAI(_apiKey);
        var systemInstruction =
            @"Você é um Tutor de Lógica Socrático.
              Contexto: O usuário está respondendo uma questão de lógica, você receberá a questão, a resposta correta, e a resposta do usuário.
              Seu Objetivo: Verificar se a resposta do usuário está certa, caso contrário ajudar com dicas simples.
            REGRAS:
            1. Seja breve, amigável e nunca dê a resposta direta se o aluno errar.
            2. Se o usuário falar sobre outros assuntos, responda educadamente para voltar ao foco do teste lógico.;
            3. Não diga ""olá!"" ou algo do tipo, lembre-se que você está em uma conversa que já estava acontecendo antes
            4. Não faça perguntas para o usuário, pois ele não terá condições de te responder, mesmo acertando a questão";

        var genConfig = new GenerationConfig
        {
            Temperature = 0.2,
            TopK = 40
        };

        var model = googleAI.GenerativeModel
            (Model.Gemini3Flash,
            generationConfig: genConfig,
            systemInstruction: new Content(systemInstruction));

        var response = await model.GenerateContent($"A questão é: {OriginalQuestion}, e a resposta certa para essa questão é: {CorrectAnswer}, verifique se o usuário respondeu corretamente, a resposta dele foi: {UserAnswer}. Se estiver errado, dê uma dica socrática sem dar a resposta e sem ajudar muito, deixe o usuário pensar por ele mesmo");

        return response.Text ?? "";

    }
}
