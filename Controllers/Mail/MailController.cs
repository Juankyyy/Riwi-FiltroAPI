using System.Text;
using System.Text.Json;
using FiltroApi.Models;

namespace FiltroApi.AddControllers
{
    public class MailController
    {
        public async void SendEmail(string toEmail, string toName, string courseName, string courseDescription, string courseSchedule, int courseDuration, int courseCapacity, string courseTeacher, string courseStatus)
        {
            // Verificacion de hora o horas
            string hoursText;
            if (courseDuration == 1)
            {
                hoursText = "Hora";
            } else {
                hoursText = "Horas";
            }
            try
            {
                // URL MailerSend
                string url = "https://api.mailersend.com/v1/email";

                // Token de autorización
                string jwtToken = "mlsn.ff334266a30b7aeddce2f66409ccc7a0410e3685053af676e14ec6877049e230";

                // Mensaje del Email
                var EmailMessage = new Email
                {
                    // Email que proporciona MailerSend
                    from = new From { email = "MS_XPsRZo@trial-yzkq340ooe34d796.mlsender.net" },
                    
                    // A donde va dirigido el email
                    to = [
                        new To { email = toEmail }
                    ],
                    // Contenido del correo
                    subject = $"Felicidades, te has matrículado a un nuevo curso: {courseName}",
                    text = $"¡Hola, {toName} recientemente tu matrícula para el curso {courseName} ha sido aceptada!\nEstado de la matrícula: {courseStatus}\n\nDETALLES DEL CURSO\nNombre: {courseName}\nDescripcion: {courseDescription}\nHorario: {courseSchedule}\nDuración de las clases: {courseDuration} {hoursText}\nCapacidad Máxima: {courseCapacity} Estudiantes\nProfesor: {courseTeacher}",
                };

                // Serializar Email
                string jsonBody = JsonSerializer.Serialize(EmailMessage);

                // Config cliente que va a enviar el correo
                using(HttpClient client = new HttpClient())
                {
                    // Autorización
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");

                    StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    // Respuesta
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    // Verificación si la respuesta es positiva o no
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Se ha enviado correctamente el correo a {toEmail} con el asunto:\n{EmailMessage.text}");
                    } else
                    {
                        Console.WriteLine($"La solicitud falló: {response.StatusCode}");
                    }
                }
            } catch {}
        }
    }
}
