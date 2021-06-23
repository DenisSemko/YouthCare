using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.Models;
using DAL.Repository.Abstract;
using BLL.Services.Abstract;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using MimeKit;
using MailKit.Net.Smtp;
using System.Globalization;

namespace BLL.Services.Concrete
{
    public class AnalysisService : IAnalysisService
    {
        private readonly IAnalysisRepository analysisRepository;
        private readonly EmailConfiguration emailConfig;
        private readonly double currentYear = DateTime.Now.Year;

        private const double minTemperature = 35.9;
        private const double maxTemperature = 37.2;
        private const double minCalmHeartBeat = 60;
        private const double maxCalmHeartBeat = 80;
        private const double minBreathingRate = 16;
        private const double maxBreathingRate = 20;
        private const double minSweatRate = 1;
        private const double maxSweatRate = 1.5;

        private const double bmrMenFirstMetric = 88.362;
        private const double bmrMenSecondMetric = 13.397;
        private const double bmrMenThirdMetric = 4.799;
        private const double bmrMenFourthMetric = 5.677;
        private const double bmrWomenFirstMetric = 447.593;
        private const double bmrWomenSecondMetric = 9.247;
        private const double bmrWomenThirdMetric = 3.098;
        private const double bmrWomenFourthMetric = 4.330;
        private const int hoursPerDay = 24;
        private const int minutesPerHour = 60;

        private const double bmiUnderweightMetric = 5;
        private const double bmiHealthyWeightMetric = 85;
        private const double bmiRiskWeightMetric = 95;
        private const string underweightCategory = "Underweight";
        private const string healthyweightCategory = "Healthy/Normal weight";
        private const string riskCategory = "At risk of overweight";
        private const string overweightCategory = "Overweight";

        public string pdfResult = "";
        public double nextTime;

        public AnalysisService(IAnalysisRepository analysisRepository, EmailConfiguration emailConfig)
        {
            this.analysisRepository = analysisRepository;
            this.emailConfig = emailConfig;
        }

        public async Task<Analysis> Update(Analysis analysis)
        {
            switch (analysis.Type.ToString())
            {
                case "Temperature":
                    if (analysis.Measure >= minTemperature && analysis.Measure <= maxTemperature)
                    {
                        analysis.Description = "The temperature result is good, it equals to " + analysis.Measure + ". You're excepted to the competition.";
                        analysis.Result = true;
                    }
                    else
                    {
                        nextTime = ((analysis.Measure * hoursPerDay) / minutesPerHour) * (double)((currentYear - analysis.SportsmanUserId.BirthDate.Year) / 100);
                        analysis.Description = "The temperature result isn't good, it equals to " + analysis.Measure + ". You're not excepted to the competition. Next time for measuring equals to " + Math.Round((double)nextTime, 2) + " hours.";
                        analysis.Result = false;
                    }
                    break;
                case "HeartBeat":
                    if (analysis.Measure >= minCalmHeartBeat && analysis.Measure <= maxCalmHeartBeat)
                    {
                        analysis.Description = "The heartbeat result is good, it equals to " + analysis.Measure + " per minute. You're excepted to the competition.";
                        analysis.Result = true;
                    }
                    else
                    {
                        nextTime = (((analysis.Measure * hoursPerDay) / minutesPerHour) * (double)((currentYear - analysis.SportsmanUserId.BirthDate.Year) / 100)) / 3;
                        analysis.Description = "The heartbeat result isn't good, it equals to " + analysis.Measure + " per minute. You're not excepted to the competition. Next time for measuring equals to " + Math.Round((double)nextTime, 2) + " hours.";
                        analysis.Result = false;
                    }
                    break;
                case "BreathingRate":
                    if (analysis.Measure >= minBreathingRate && analysis.Measure <= maxBreathingRate)
                    {
                        analysis.Description = "The breathing rate result is good, it equals to " + analysis.Measure + " per minute. You're excepted to the competition.";
                        analysis.Result = true;
                    }
                    else
                    {
                        nextTime = ((analysis.Measure * hoursPerDay) / minutesPerHour) * (double)((currentYear - analysis.SportsmanUserId.BirthDate.Year) / 100);
                        analysis.Description = "The breathing rate isn't good, it equals to " + analysis.Measure + " per minute. You're not excepted to the competition. Next time for measuring equals to " + Math.Round((double)nextTime, 2) + " hours.";
                        analysis.Result = false;
                    }
                    break;
                case "SweatRate":
                    if (analysis.Measure >= minSweatRate && analysis.Measure <= maxSweatRate)
                    {
                        analysis.Description = "The sweating rate result is good, it equals to " + analysis.Measure + "L per hour. You're excepted to the competition.";
                        analysis.Result = true;
                    }
                    else
                    {
                        nextTime = ((analysis.Measure * hoursPerDay) / minutesPerHour) * (double)((currentYear - analysis.SportsmanUserId.BirthDate.Year) / 100);
                        analysis.Description = "The sweating rate isn't good, it equals to " + analysis.Measure + "L per hour. You're not excepted to the competition, please, contact your doctor.";
                        analysis.Result = false;
                    }
                    break;
                case "BMR":
                    if (analysis.SportsmanUserId.Gender == "Male")
                    {
                        var bmrMaleCount = bmrMenFirstMetric + (bmrMenSecondMetric * analysis.Weight) + (bmrMenThirdMetric * analysis.Height) + (bmrMenFourthMetric * (currentYear - analysis.SportsmanUserId.BirthDate.Year));
                        analysis.Measure = Math.Round((double)bmrMaleCount, 2);
                        analysis.Description = "Your BMR equals to " + analysis.Measure + " kcals (per day)";
                    }
                    else if (analysis.SportsmanUserId.Gender == "Female")
                    {
                        var bmrFemaleCount = bmrWomenFirstMetric + (bmrWomenSecondMetric * analysis.Weight) + (bmrWomenThirdMetric * analysis.Height) + (bmrWomenFourthMetric * (currentYear - analysis.SportsmanUserId.BirthDate.Year));
                        analysis.Measure = Math.Round((double)bmrFemaleCount, 2); ;
                        analysis.Description = "Your BMR equals to " + analysis.Measure + " kcals (per day)";
                    }
                    break;
                case "BMI":
                    var bmiCount = analysis.Weight / (analysis.Height * analysis.Height);
                    analysis.Measure = Math.Round((double)bmiCount, 2);
                    if (analysis.Measure < bmiUnderweightMetric)
                    {
                        analysis.Description = "Your BMI result is " + analysis.Measure + "%. It belongs to the category: '" + underweightCategory + "'. You're not excepted to the competition, please, contact your doctor.";
                        analysis.Result = false;
                    }
                    else if (analysis.Measure > bmiUnderweightMetric && analysis.Measure < bmiHealthyWeightMetric)
                    {
                        analysis.Description = "Your BMI result is " + analysis.Measure + "%. It belongs to the category: '" + healthyweightCategory + "'. You're excepted to the competition.";
                        analysis.Result = true;
                    }
                    else if (analysis.Measure > bmiHealthyWeightMetric && analysis.Measure < bmiRiskWeightMetric)
                    {
                        analysis.Description = "Your BMI result is " + analysis.Measure + "%. It belongs to the category: '" + riskCategory + "'. You're not excepted to the competition, please, contact your doctor.";
                        analysis.Result = false;
                    }
                    else if (analysis.Measure > bmiRiskWeightMetric)
                    {
                        analysis.Description = "Your BMI result is " + analysis.Measure + "%. It belongs to the category: '" + overweightCategory + "'. You're not excepted to the competition, please, contact your doctor.";
                        analysis.Result = false;
                    }
                    break;
            }

            var sb = new StringBuilder();
            sb.AppendFormat(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                
                                <div class='title'><h1>YouthCare</h1></div>
                                    <h2 class='title'>Analysis Result</h2><br><br><br><br>
                                    <div>
	 	                                    <p class='info'>Dear {0},<br>
                                                You have passed the {1} Analysis on {2} {3}, {4}! <br>
                                                Please look through your results and contact your doctor.<br>
                                                Take care and stay safe!
                                            </p>

                                    </div><br><br><br><br>
                                    <table align='center'>
                                        <tr>
                                            <th>Id</th>
                                            <th>Type</th>
                                            <th>Measure</th>
                                            <th>Result</th>
                                        </tr>", analysis.SportsmanUserId.Name, analysis.Type, analysis.Date.ToString("MMMM", new CultureInfo("en")), analysis.Date.Day, analysis.Date.Year);
            sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", analysis.Id, analysis.Type, analysis.Measure, analysis.Result);

            sb.AppendFormat(@"
                                </table><br><br><br><br><br><br>
                                <p class='info'>Conclusion: {0}</p>
                                <p class='end'>YouthCare, {1}</p>
                            </body>
                        </html>", analysis.Description, DateTime.Now.Year);


            pdfResult = sb.ToString();

            var result = await analysisRepository.Update(analysis);

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(emailConfig.From));
            emailMessage.To.Add(new MailboxAddress(analysis.SportsmanUserId.Email));
            emailMessage.Subject = "YouthCare - Analysis Passed";

            string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "analysis-email.html");
            string EmailTemplateText = File.ReadAllText(FilePath);
            BodyBuilder emailBodyBuilder = new BodyBuilder();
            emailBodyBuilder.HtmlBody = EmailTemplateText;
            emailMessage.Body = emailBodyBuilder.ToMessageBody();

            var client = new SmtpClient();
            await client.ConnectAsync(emailConfig.SmtpServer, emailConfig.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(emailConfig.UserName, emailConfig.Password);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
            client.Dispose();

            return result;
        }

        public string GetPdfResult()
        {
            return pdfResult;
        }
    
    }
}
