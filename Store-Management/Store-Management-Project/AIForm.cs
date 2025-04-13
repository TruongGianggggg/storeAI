using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Store_Management_Project
{
    public partial class AIForm : Form
    {
        public static AIForm gI;

        static List<AIMessage> messagesHistory = new List<AIMessage>()
        {
            new AIMessage("system", "Bạn là một trợ lý ảo thông minh được gọi qua API từ một ứng dụng quản lý cửa hàng, hãy trả lời câu hỏi của người dùng một cách tự nhiên và thân thiện, tránh sử dụng ngôn ngữ không phù hợp và không trả lời các câu hỏi liên quan đến chính trị, tôn giáo, tình dục,..., tránh thêm các biểu tượng cảm xúc và định dạng markdown vào phản hồi."),
        };

        static HttpClient httpClient = new HttpClient();

        static Author bot = new Author(null, "AI");
        static Author me = new Author(null, "Bạn");

        static bool hasBLL;

        public AIForm(BaseBLL bll)
        {
            InitializeComponent();
            radChat1.Author = me;
            if (!hasBLL)
            {
                hasBLL = true;
                messagesHistory[0].Content += "\nDưới đây là nội dung CSDL của ứng dụng:\n" + bll.GetAIText();
            }
            foreach (var message in messagesHistory.Where(m => m.Role != "system"))
            {
                if (message.Role == "user")
                    radChat1.AddMessage(new ChatTextMessage(message.Content, me, message.Time));
                else
                    radChat1.AddMessage(new ChatTextMessage(message.Content, bot, message.Time));
            }
        }

        static async ValueTask<string> CallOpenRouterAPI(string model = "deepseek/deepseek-chat-v3-0324:free")
        {
            JsonObject jsonContent = new JsonObject
            {
                { "model", model },
                { "messages", JsonValue.Create(messagesHistory) }
            };
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://openrouter.ai/api/v1/chat/completions"),
                Headers =
                {
                    Authorization = new AuthenticationHeaderValue("Bearer", "")
                },
                Content = new StringContent(jsonContent.ToJsonString(), Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = await httpClient.SendAsync(request);
            string responseContent = await response.Content.ReadAsStringAsync();
            JsonArray arr = JsonNode.Parse(responseContent.Trim().Trim(Environment.NewLine.ToCharArray()))?["choices"]?.AsArray();
            if (arr is null || arr.Count == 0)
                return "error";
            AIMessage aiMessage = arr.Last(e => e?["message"]?["role"]?.GetValue<string>() == "assistant")?["message"]?.Deserialize<AIMessage>();
            if (aiMessage is null)
                return "error";
            aiMessage.Time = DateTime.Now;
            messagesHistory.Add(aiMessage);
            return aiMessage.Content;
        }

        public static void TryOpen(BaseBLL bll, Form parent)
        {
            if (gI != null && !gI.IsDisposed)
            {
                gI.BringToFront();
                return;
            }
            (gI = new AIForm(bll)).Show(parent);
        }

        private async void radChat1_SendMessage(object sender, SendMessageEventArgs e)
        {
            if (!(e.Message is ChatTextMessage message))
                return;
            string prompt = message.Message;
            radChat1.AutoAddUserMessages = false;

            if (messagesHistory.Count > 20)
                messagesHistory.RemoveAt(1);
            messagesHistory.Add(new AIMessage("user", prompt));
            string response = await CallOpenRouterAPI();
            if (response == "error")
            {
                messagesHistory.RemoveAt(messagesHistory.Count - 1);
                response = "Tôi không thể trả lời câu hỏi của bạn lúc này, hãy thử lại sau ít phút.";
            }
            if (messagesHistory.Count > 20)
                messagesHistory.RemoveAt(1);
            radChat1.AutoAddUserMessages = true;
            radChat1.AddMessage(new ChatTextMessage(response, bot, DateTime.Now));
        }
    }
}
