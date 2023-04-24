using Azure;
using Azure.AI.Translation.Text;

namespace AwesomeApplication.BL
{
    public class Awesome : IAwesome
    {
        private TextTranslationClient client;

        public Awesome()
        {
            this.client = new TextTranslationClient(new AzureKeyCredential("abcd"), "westus2");
        }

        public async Task<string> TranslateAsync(string text, string targetLanguage, string sourceLanguage = null, CancellationToken cancellationToken = default)
        {
            // TranslateAsync throws when request is not valid - https://learn.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-translate#required-parameters
            var translationResponse = this.client.TranslateAsync(targetLanguage, text, sourceLanguage, cancellationToken).Result;
            var translations = translationResponse.Value;

            return await Task.FromResult(translations[0].Translations[0].Text);
        }
    }
}
