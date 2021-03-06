﻿using AutoMapper;
using ElectronicsStore.Domain.Models;
using ElectronicsStore.Domain.Services;
using ElectronicsStore.Domain.Services.Communication;
using ElectronicsStore.Extensions;
using ElectronicsStore.Resources.Errors;
using ElectronicsStore.Resources.Requests;
using ElectronicsStore.Resources.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicsStore.Controllers {

    [Authorize]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    public class ProductsController : ControllerBase {

        private readonly IProductsService productsService;
        private readonly IMapper mapper;

        public ProductsController(IProductsService productsService, IMapper mapper) {
            this.productsService = productsService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("all")]
        public async Task<ActionResult> GetAllAsync([FromQuery] PaginationRequest request) {
            IEnumerable<Product> products = await productsService.GetAllAsync(request.startIndex, request.perPage);
            if (products != null)
                return Ok(mapper.Map<IEnumerable<Product>, IEnumerable<ProductResponse>>(products));
            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet("get")]
        public async Task<ActionResult> GetByIdAsync([FromQuery] ProductIdRequest request) {
            Product product = await productsService.FindByIdAsync(request.ProductId);
            if (product != null)
                return Ok(mapper.Map<Product, ProductResponse>(product));
            return NotFound();
        }

        [HttpPost("create")]
        [Consumes(contentType: "application/json", otherContentTypes: "multipart/form-data")]
        public async Task<ActionResult> PostAsync([FromForm] ProductSaveRequest request) {
            if (!ModelState.IsValid)
                return BadRequest(new ErrorResponse { Error = ModelState.GetErrorMessages(), Status = false });
            Product product = mapper.Map<ProductSaveRequest, Product>(request);
            ProductStatusResponse response = await productsService.SaveAsync(request, product);
            if (response.Status)
                return Ok(mapper.Map<Product, ProductResponse>(response.Resource));
            return BadRequest(new ErrorResponse { Error = response.Message, Status = response.Status });
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateAsync([FromQuery] ProductUpdateRequest request) {
            if (!ModelState.IsValid)
                return BadRequest(new ErrorResponse { Error = ModelState.GetErrorMessages(), Status = false });
            ProductStatusResponse response = await productsService.UpdateAsync(request);
            if (response.Status)
                return Ok(mapper.Map<Product, ProductResponse>(response.Resource));
            return BadRequest(new ErrorResponse { Error = response.Message, Status = response.Status });
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteAsync([FromQuery] ProductIdRequest request) {
            bool status = await productsService.DeleteAsync(request.ProductId);
            if (status)
                return Ok();
            return NotFound(new ErrorResponse { Error = "Product Not Found.", Status = status });
        }
    }
}
