using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers;

public class HomeController : Controller
{
  readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }

  public IActionResult Index() => View();

  [Route("/village/")]
  public IActionResult Add() => View();

  [Route("/village/")]
  [HttpPost]
  public IActionResult updateAdd()
  {
    ViewData["Name"] = Request.Form["name"];
    ViewData["People"] = Int32.Parse(Request.Form["people"]);
    return View();
  }

  [Route("/village/{identity?}")]
  public IActionResult Id(string identity) => baseView(identity);

  [Route("/village/{identity?}")]
  [HttpPost]
  public IActionResult deleteId(string identity) => baseView(identity);


  [Route("/village/{identity?}/name")]
  public IActionResult Name(string identity) => baseView(identity);

  [Route("/village/{identity?}/name")]
  [HttpPost]
  public IActionResult updateName(string identity)
  {
    ViewData["Name"] = Request.Form["name"];
    return baseView(identity);
  }

  [Route("/village/{identity?}/people")]
  public IActionResult People(string identity) => baseView(identity);

  [Route("/village/{identity?}/people")]
  [HttpPost]
  public IActionResult updatePeople(string identity)
  {
    ViewData["People"] = Int32.Parse(Request.Form["people"]);
    return baseView(identity);
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }

  IActionResult baseView(string identity)
  {
    var id = getNumberFromIdentity(identity);
    if (id < 0) return View("Error");
    ViewData["Id"] = id;
    return View();
  }

  int getNumberFromIdentity(string identity)
  {
    try { return Int32.Parse(identity); }
    catch (System.FormatException) { return -1; }
  }
}
