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

namespace BLL.Services.Concrete
{
    public class AnalysisService : IAnalysisService
    {
        private readonly IAnalysisRepository analysisRepository;
        private readonly int currentYear = DateTime.Now.Year;
        
        private const double minTemperature = 36.6;
        private const double maxTemperature = 37.2;
        private const double minCalmHeartBeat = 60;
        private const double maxCalmHeartBeat = 80;
        private const double minBreathingRate = 16;
        private const double maxBreathingRate = 20;
        private const double minSweatRate = 1;
        private const double maxSweatRate = 1.5;

        private const double bmrMenFirstMetric = 66;
        private const double bmrMenSecondMetric = 13.7;
        private const double bmrMenThirdMetric = 5;
        private const double bmrMenFourthMetric = 6.8;
        private const double bmrWomenFirstMetric = 655;
        private const double bmrWomenSecondMetric = 9.6;
        private const double bmrWomenThirdMetric = 1.8;
        private const double bmrWomenFourthMetric = 4.7;

        private const double bmiUnderweightMetric = 5;
        private const double bmiHealthyWeightMetric = 85;
        private const double bmiRiskWeightMetric = 95;
        private const string underweightCategory = "Underweight";
        private const string healthyweightCategory = "Healthy/Normal weight";
        private const string riskCategory = "At risk of overweight";
        private const string overweightCategory = "Overweight";

        public AnalysisService(IAnalysisRepository analysisRepository)
        {
            this.analysisRepository = analysisRepository;
        }
        
        public async Task<Analysis> Update(Analysis analysis)
        {
            switch (analysis.Type.ToString())
            {
                case "Temperature":
                    if(analysis.Measure >= minTemperature && analysis.Measure <= maxTemperature)
                    {
                        analysis.Description = "The temperature result is good, it equals to " + analysis.Measure + ". You're excepted to the competition.";
                        analysis.Result = true;
                    } else
                    {
                        analysis.Description = "The temperature result isn't good, it equals to " + analysis.Measure + ". You're not excepted to the competition, please, contact your doctor.";
                        analysis.Result = false;
                    }
                    break;
                case "HeartBeat":
                    if(analysis.Measure >= minCalmHeartBeat && analysis.Measure <= maxCalmHeartBeat)
                    {
                        analysis.Description = "The heartbeat result is good, it equals to " + analysis.Measure + " per minute. You're excepted to the competition.";
                        analysis.Result = true;
                    } else
                    {
                        analysis.Description = "The heartbeat result isn't good, it equals to " + analysis.Measure + " per minute. You're not excepted to the competition, please, contact your doctor.";
                        analysis.Result = false;
                    }
                    break;
                case "BreathingRate":
                    if(analysis.Measure >= minBreathingRate && analysis.Measure <= maxBreathingRate)
                    {
                        analysis.Description = "The breathing rate result is good, it equals to " + analysis.Measure + " per minute. You're excepted to the competition.";
                        analysis.Result = true;
                    } else
                    {
                        analysis.Description = "The breathing rate isn't good, it equals to " + analysis.Measure + " per minute. You're not excepted to the competition, please, contact your doctor.";
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
                        analysis.Description = "The sweating rate isn't good, it equals to " + analysis.Measure + "L per hour. You're not excepted to the competition, please, contact your doctor.";
                        analysis.Result = false;
                    }
                    break;
                case "BMR":
                    if(analysis.SportsmanUserId.Gender == "Male")
                    {
                        var bmrMaleCount = bmrMenFirstMetric + (bmrMenSecondMetric * analysis.Weight) + (bmrMenThirdMetric * analysis.Height) + (bmrMenFourthMetric * (currentYear - analysis.SportsmanUserId.BirthDate.Year));
                        analysis.Measure = Math.Round((double)bmrMaleCount, 2);
                        analysis.Description = "Your BMR equals to " + analysis.Measure + " kcals (per day)";
                    } else if(analysis.SportsmanUserId.Gender == "Female")
                    {
                        var bmrFemaleCount = bmrWomenFirstMetric + (bmrWomenSecondMetric * analysis.Weight) + (bmrWomenThirdMetric * analysis.Height) + (bmrWomenFourthMetric * (currentYear - analysis.SportsmanUserId.BirthDate.Year));
                        analysis.Measure = Math.Round((double)bmrFemaleCount, 2); ;
                        analysis.Description = "Your BMR equals to " + analysis.Measure + " kcals (per day)";
                    }
                    break;
                case "BMI":
                    var bmiCount = analysis.Weight / (analysis.Height * analysis.Height);
                    analysis.Measure = Math.Round((double)bmiCount, 2);
                    if(analysis.Measure < bmiUnderweightMetric)
                    {
                        analysis.Description = "Your BMI result is " + analysis.Measure + "%. It belongs to the category: '" + underweightCategory + "'. You're not excepted to the competition, please, contact your doctor.";
                        analysis.Result = false;
                    } else if(analysis.Measure > bmiUnderweightMetric && analysis.Measure < bmiHealthyWeightMetric)
                    {
                        analysis.Description = "Your BMI result is " + analysis.Measure + "%. It belongs to the category: '" + healthyweightCategory + "'. You're excepted to the competition.";
                        analysis.Result = true;
                    } else if(analysis.Measure > bmiHealthyWeightMetric && analysis.Measure < bmiRiskWeightMetric)
                    {
                        analysis.Description = "Your BMI result is " + analysis.Measure + "%. It belongs to the category: '" + riskCategory + "'. You're not excepted to the competition, please, contact your doctor.";
                        analysis.Result = false;
                    } else if(analysis.Measure > bmiRiskWeightMetric)
                    {
                        analysis.Description = "Your BMI result is " + analysis.Measure + "%. It belongs to the category: '" + overweightCategory + "'. You're not excepted to the competition, please, contact your doctor.";
                        analysis.Result = false;
                    }
                    break;
                    //var bmrMaleCount = 934 * 2 + (bmrMenSecondMetric * analysis.Weight) + (bmrMenThirdMetric * analysis.Height) + (bmrMenFourthMetric * (currentYear - analysis.SportsmanUserId.BirthDate.Year));

                    //var bmiCount = 67 / (1.81 * 1.81);
            }
            var result = await analysisRepository.Update(analysis);
            return result;
        }
    }
}
