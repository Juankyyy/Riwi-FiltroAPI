using System.Text;
using System.Text.Json;
using FiltroApi.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace FiltroApi.AddControllers
{
    public class MailController
    {
        public async void SendEmail(string toEmail, string toName, string courseName, string courseDescription, string courseSchedule, string courseDuration, int courseCapacity, string courseTeacher)
        {
            try
            {
                string url = "https://api.mailersend.com/v1/email";

                string jwtToken = "mlsn.ff334266a30b7aeddce2f66409ccc7a0410e3685053af676e14ec6877049e230";

                var EmailMessage = new Email
                {
                    from = new From { email = "MS_XPsRZo@trial-yzkq340ooe34d796.mlsender.net" },
                    to = [
                        new To { email = toEmail }
                    ],
                    subject = $"Felicidades, te has matrículado a un nuevo curso: {courseName}",
                    text = $"Hola, {toName} recientemente tu matrícula para el curso {courseName} ha sido aceptada\nDETALLES DEL CURSO\nNombre: {courseName}\nDescripcion: {courseDescription}\nHorario: {courseSchedule}\nDuración de las clases: {courseDuration}\nCapacidad Máxima: {courseCapacity}\nProfesor: {courseTeacher}",
                };

                string jsonBody = JsonSerializer.Serialize(EmailMessage);

                using(HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");

                    StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Se ha enviado correctamente el correo a {toEmail} con el asunto:\n {EmailMessage.text}");
                    } else
                    {
                        Console.WriteLine($"La solicitud falló: {response.StatusCode}");
                    }
                }
            } catch
            {
                
            }
        }
    }
}
