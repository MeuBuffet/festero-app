using System.Text;
using RestSharp;
using FesteroApp.SharedKernel;
using SrShut.Common;

namespace FesteroApp.Application.Services;

public class EmailService : IEmailService
{
    private readonly string _apiKey = "SUA_API_KEY";
    private readonly string _listId = "SEU_LIST_ID";
    private readonly string _dataCenter = "us17";

    public async Task Send(string email, string password, string name)
    {
        try
        {
            var client = new RestClient($"https://{_dataCenter}.api.mailchimp.com/3.0");
            var request = new RestRequest($"lists/{_listId}/members", Method.Post);

            var authHeader = Convert.ToBase64String(Encoding.ASCII.GetBytes($"anystring:{_apiKey}"));
            request.AddHeader("Authorization", $"Basic {authHeader}");

            var (firstName, lastName) = name.SplitFullName();
            var cryptPassword = Base64.Encode(password);
            
            var body = new
            {
                email_address = email,
                status = "subscribed",
                merge_fields = new
                {
                    FNAME = firstName,
                    LNAME = lastName
                }
            };

            request.AddJsonBody(body);

            var response = await client.ExecuteAsync(request);
            
            Throw.IsFalse(response.IsSuccessful, "EmailService.Send", "Não foi possível enviar o email.");
        }
        catch (Exception ex)
        {
            var message = ex.Message;
        }
    }
}