﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.Models;
using BLL.Services.Abstract;
using DAL.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using CIL.DTOs;
using AutoMapper;
using DAL;
using DinkToPdf;
using System.IO;
using DinkToPdf.Contracts;

namespace YouthCareServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisResultController : ControllerBase
    {
        private readonly IAnalysisService analysisService;
        private readonly IAnalysisResultService analysisResultService;
        private readonly ApplicationContext myDbContext;
        private readonly IConverter converter;
        private readonly IMapper mapper;
        public AnalysisResultController(IAnalysisService analysisService, ApplicationContext myDbContext, IMapper mapper, IAnalysisResultService analysisResultService, IConverter converter)
        {
            this.analysisService = analysisService;
            this.myDbContext = myDbContext;
            this.mapper = mapper;
            this.analysisResultService = analysisResultService;
            this.converter = converter;
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<IEnumerable<Analysis>>> GetByUserId(Guid id)
        {
            try
            {
                var result = await analysisResultService.GetByUserId(id);
                if (result == null) return NotFound();

                return result.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPut]
        public async Task<Analysis> Update(AnalysisDto analysisDto)
        {
            try
            {
               var selectedSportsman = await myDbContext.Users.Where(c => c.Id == analysisDto.SportsmanUserId).FirstOrDefaultAsync();
               var selectedDoctor = await myDbContext.Users.Where(c => c.Id == analysisDto.DoctorUserId).FirstOrDefaultAsync();
                var analysis = new Analysis
                {
                    Id = analysisDto.Id,
                    SportsmanUserId = selectedSportsman,
                    DoctorUserId = selectedDoctor,
                    Name = analysisDto.Name,
                    Date = analysisDto.Date,
                    Type = analysisDto.Type,
                    Measure = analysisDto.Measure,
                    Weight = analysisDto.Weight,
                    Height = analysisDto.Height,
                    Description = analysisDto.Description,
                    Result = analysisDto.Result

                };
                await analysisService.Update(analysis);

                var globalSettings = new GlobalSettings
                {
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    DocumentTitle = "YouthCare_Analysis_Report",
                    Out = @"D:\YouthCare_Analysis_Report.pdf"
                };

                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = analysisService.GetPdfResult(),
                    WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "style.css") }
                };
                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };
                var file = converter.Convert(pdf);

                return analysis;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
