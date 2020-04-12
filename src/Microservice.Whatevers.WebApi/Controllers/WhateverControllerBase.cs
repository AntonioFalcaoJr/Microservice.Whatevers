using Microsoft.AspNetCore.Mvc;

namespace Microservice.Whatevers.WebApi.Controllers
{
    [ApiController, Route("api/v{version:apiVersion}/[controller]")]
    public class WhateverControllerBase : ControllerBase { }
}