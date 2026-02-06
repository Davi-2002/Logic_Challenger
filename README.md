# 🧠 Logic Challenger

![Build Status](https://github.com/Davi-2002/Logic_Challenger/actions/workflows/main_logic-challenger-ai.yml/badge.svg)
![.NET](https://img.shields.io/badge/.NET-9.0-purple)
![Azure](https://img.shields.io/badge/Azure-Hosted-blue)

Um desafio de lógica infinito alimentado por Inteligência Artificial. Este projeto utiliza a API do Google Gemini para gerar quebra-cabeças personalizados, validar respostas e fornecer feedback educativo em tempo real.

🔗 **Acesse o projeto online:** [Logic Challenger](https://logic-challenger-ai-hahgfmfsh0ambcc3.northcentralus-01.azurewebsites.net/)

---

## 🚀 Funcionalidades

* **Geração Procedural com IA:** Criação de problemas de lógica únicos a cada rodada usando o `Mscc.GenerativeAI`.
* **Seleção de Dificuldade:** Permite ao usuário escolher o nível do desafio antes de começar.
* **Feedback Inteligente:** O sistema não apenas diz se está certo ou errado, mas explica a lógica por trás da resposta.
* **Design Responsivo:** Interface adaptada para funcionar bem em desktops e dispositivos móveis.
* **CI/CD Automatizado:** Pipeline de integração e entrega contínua configurado com GitHub Actions e Azure Web Apps.

---

## 🛠️ Tecnologias Utilizadas

Este projeto foi desenvolvido aplicando práticas modernas de desenvolvimento de software:

* **Linguagem:** C# 13 / .NET 9 (STS)
* **Framework Web:** ASP.NET Core MVC
* **IA Integration:** Google Gemini API (via pacote `Mscc.GenerativeAI`)
* **Testes:** xUnit & Moq (para Mocks e testes unitários)
* **Cloud & DevOps:**
    * Microsoft Azure App Service (Hospedagem)
    * GitHub Actions (Pipeline de CI/CD com testes automatizados)

---

## ⚙️ Como Rodar Localmente

Para rodar este projeto na sua máquina, você precisará do **.NET 9 SDK** e de uma **API Key do Google Gemini**.

### 1. Clonar o repositório
```bash
git clone [https://github.com/Davi-2002/Logic_Challenger.git](https://github.com/Davi-2002/Logic_Challenger.git)
cd Logic_Challenger
```
### 2. Configurar a Chave da API (Segurança)
Este projeto utiliza User Secrets para não expor chaves no código fonte. Não coloque sua chave diretamente no código!

Execute o comando abaixo na pasta do projeto principal (onde está o .csproj):
```bash
dotnet user-secrets init
dotnet user-secrets set "GeminiKey" "SUA_CHAVE_DA_API_AQUI"
```
### 3. Restaurar dependências e Rodar
```bash
dotnet restore
dotnet run
```
O projeto estará acessível em http://localhost:5000 (ou a porta indicada no terminal)

---

## 🧪 Testes
O projeto conta com uma suíte de testes unitários para garantir a integridade da lógica e da integração com a IA.

Para rodar os testes manualmente:
```bash
dotnet test
```
Nota: O pipeline de CI/CD está configurado para impedir o deploy caso algum teste falhe, garantindo a qualidade em produção.





