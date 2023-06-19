
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  public class ProductsController : BaseApiController
  {
    private readonly IGenericRepository<Product> _productsRepo;
    private readonly IGenericRepository<ProductType> _productTypesRepo;
    private readonly IGenericRepository<Pot> _potsRepo;
    private readonly IGenericRepository<Images> _imagesRepo;

    private readonly IGenericRepository<Review> _reviewsRepo;
    private readonly IMapper _mapper;

    public ProductsController(IGenericRepository<Product> productsRepo, IGenericRepository<ProductType> productTypesRepo, IGenericRepository<Pot> potsRepo, IGenericRepository<Images> imagesRepo, IGenericRepository<Review> reviewRepo, IMapper mapper)
    {
      _productsRepo = productsRepo;
      _productTypesRepo = productTypesRepo;
      _potsRepo = potsRepo;
      _imagesRepo = imagesRepo;
      _mapper = mapper;
      _reviewsRepo = reviewRepo;
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<ProductToReturnDTO>>> GetProductsAsync(
      [FromQuery] ProductSpecParams productParams)
    {
      var spec = new ProductsWithTypesAndPotsAndImagesSpecification(productParams);
      var countSpec = new ProductWithFiltersForCountSpecification(productParams);
      var totalItems = await _productsRepo.CountAsync(countSpec);
      var products = await _productsRepo.ListAsync(spec);
      var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(products);
      return Ok(new Pagination<ProductToReturnDTO>(productParams.PageIndex, productParams.PageSize, totalItems, data));
    }


    [HttpGet("reviews")]
    public async Task<ActionResult<Pagination<ReviewToReturnDTO>>>
    GetReviewsAsync(
      [FromQuery] ReviewSpecParam reviewParams)
    {
      var spec = new ReviewWithProductAndDateSpecification(reviewParams);
      var countSpec = new ReviewWithFiltersForCountSpecification(reviewParams);
      var totalItems = await _reviewsRepo.CountAsync(countSpec);
      var reviews = await _reviewsRepo.ListAsync(spec);
      var data = _mapper.Map<IReadOnlyList<Review>, IReadOnlyList<ReviewToReturnDTO>>(reviews);
      return Ok(new Pagination<ReviewToReturnDTO>(reviewParams.PageIndex, reviewParams.PageSize, totalItems, data));
    }

    [HttpPost("reviews")]
    public async Task<ActionResult<Review>> PostReviewAsync(Review review)
    {
      var createdReview = await _reviewsRepo.CreateAsync(review);
      return Ok(createdReview);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductToReturnDTO>> GetProductAsync(int id)
    {
      var spec = new ProductsWithTypesAndPotsAndImagesSpecification(id);
      var product = await _productsRepo.GetEntityWithSpec(spec);
      if (product == null) return NotFound(new ApiResponse(404));
      return _mapper.Map<Product, ProductToReturnDTO>(product);
    }

    [HttpGet("product/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
    {
      var spec = new ProductsWithTypesAndPotsAndImagesSpecification(id);
      var product = await _productsRepo.GetEntityWithSpec(spec);
      if (product == null) return NotFound(new ApiResponse(404));
      ImagesToReturnDTO imagesToReturnDTO = _mapper.Map<Images, ImagesToReturnDTO>(product.Images);
      product.Images.Brown = imagesToReturnDTO.Brown;
      product.Images.Grey = imagesToReturnDTO.Grey;
      product.Images.Purple = imagesToReturnDTO.Purple;
      product.Images.White = imagesToReturnDTO.White;
      System.Console.WriteLine(product.Images.Brown);
      return product;
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypesAsync()
    {
      var productTypes = await _productTypesRepo.ListAllAsync();
      return Ok(productTypes);
    }

    [HttpGet("pots")]
    public async Task<ActionResult<IReadOnlyList<Pot>>> GetPotsAsync()
    {
      var pots = await _potsRepo.ListAllAsync();
      return Ok(pots);
    }

    [HttpGet("images")]
    public async Task<ActionResult<IReadOnlyList<Images>>> GetImagesAsync()
    {
      var images = await _imagesRepo.ListAllAsync();
      return Ok(images);
    }

  }
}
