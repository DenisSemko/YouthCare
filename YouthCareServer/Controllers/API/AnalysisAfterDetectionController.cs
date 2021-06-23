using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using DinkToPdf;
using System.IO;
using DinkToPdf.Contracts;
using DAL.Repository.Abstract;
using BLL.Services.Abstract;
using CIL.Models;

namespace YouthCareServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisAfterDetectionController : ControllerBase
    {
        private readonly IAnalysisRepository analysisRepository;
        private IConverter converter;
        private readonly IAnalysisService analysisService;

        public AnalysisAfterDetectionController(IAnalysisRepository analysisRepository, IAnalysisService analysisService, IConverter converter)
        {
            this.analysisRepository = analysisRepository;
            this.analysisService = analysisService;
            this.converter = converter;
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Analysis>> GetById(Guid id)
        {
            try
            {
                var result = await analysisRepository.GetAnalysisByUserId(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<Analysis> Update(Analysis analysisDto)
        {
            try
            {
                var result = await analysisService.Update(analysisDto);

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

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
