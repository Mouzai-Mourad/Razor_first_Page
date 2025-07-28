namespace Razor_first_Page.Services
{
	public interface IMessageService
	{
		string GetMessage();
		string GetMessageWithNom(string nom);
	}

	public class MessageService: IMessageService
	{
		public string GetMessage()
		{
			string[] messages = {"Bonjours!", "Salut!", "Hello!"};
			Random random = new Random();
			return messages[random.Next(messages.Length)];
		}

		public string GetMessageWithNom(string nom)
		{
			if (string.IsNullOrEmpty(nom))
			{
				return GetMessage();
			}
			string[] messages = { $"Bonjours!, {nom}", $"Salut! {nom}", $"Hello! {nom}" };
			Random random = new Random();
			return messages[random.Next(messages.Length)];
		}	
	}
}
