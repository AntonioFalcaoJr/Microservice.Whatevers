using Microsoft.AspNetCore.Mvc;

namespace Microservice.Whatevers.Api.Controllers
{
    [ApiController, Route("api/v{version:apiVersion}/[controller]")]
    public class WhateverControllerBase : ControllerBase { }
}