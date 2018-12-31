using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FracfocusAPI.Models;
using FracfocusAPI.Interfaces;
using FracfocusAPI.Repositories;

namespace FracfocusAPI.Controllers
{
    [Route("")]
    [Route("api")]
    [Route("api/fracfocus")]
    [ApiController]
    public class FracfocusController : Controller
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public FracfocusController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Produces(typeof(List<Fracfocus>))]
        public IActionResult GetAllInfo()
        {
            try
            {
                var info = _repository.Fracfocus.FindAll();

                _logger.LogInfo($"Returned all well info from database.");

                return Ok(info);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllInfo action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{api}")]
        public IActionResult GetWellInfoByAPI(string api)
        {
            try
            {
                var info = _repository.Fracfocus.FindByCondition(x => x.Apinumber.Equals(api));

                if (!info.Any())
                {
                    _logger.LogError($"Well info with api number: {api}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with api number: {api}");
                    return Ok(info);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetWellInfoByAPI action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
    #region back up
    //public FracfocusController(IRepositoryWrapper repoWrapper)
    //{
    //    _repoWrapper = repoWrapper;
    //}

    ////public FracfocusController(FracfocusDBContext context)
    ////{
    ////    _context = context;
    ////}

    //// GET: api/Fracfocus
    ////[HttpGet]
    ////public IEnumerable<Fracfocus> GetFracfocus()
    ////{
    ////    return _context.Fracfocus;
    ////}

    //[HttpGet]
    //public Tuple<IEnumerable<Fracfocus>> Get()
    //{
    //    var ff = _repoWrapper.Fracfocus.FindByCondition(x => x.Apinumber.Equals("42325339190000"));
    //    return new Tuple<IEnumerable<Fracfocus>>(ff);
    //}

    //// GET: api/Fracfocus/5
    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetFracfocus([FromRoute] Guid id)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }

    //    var fracfocus = await _context.Fracfocus.FindAsync(id);

    //    if (fracfocus == null)
    //    {
    //        return NotFound();
    //    }

    //    return Ok(fracfocus);
    //}

    //// PUT: api/Fracfocus/5
    //[HttpPut("{id}")]
    //public async Task<IActionResult> PutFracfocus([FromRoute] Guid id, [FromBody] Fracfocus fracfocus)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }

    //    if (id != fracfocus.PKey)
    //    {
    //        return BadRequest();
    //    }

    //    _context.Entry(fracfocus).State = EntityState.Modified;

    //    try
    //    {
    //        await _context.SaveChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!FracfocusExists(id))
    //        {
    //            return NotFound();
    //        }
    //        else
    //        {
    //            throw;
    //        }
    //    }

    //    return NoContent();
    //}

    //// POST: api/Fracfocus
    //[HttpPost]
    //public async Task<IActionResult> PostFracfocus([FromBody] Fracfocus fracfocus)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }

    //    _context.Fracfocus.Add(fracfocus);
    //    try
    //    {
    //        await _context.SaveChangesAsync();
    //    }
    //    catch (DbUpdateException)
    //    {
    //        if (FracfocusExists(fracfocus.PKey))
    //        {
    //            return new StatusCodeResult(StatusCodes.Status409Conflict);
    //        }
    //        else
    //        {
    //            throw;
    //        }
    //    }

    //    return CreatedAtAction("GetFracfocus", new { id = fracfocus.PKey }, fracfocus);
    //}

    //// DELETE: api/Fracfocus/5
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteFracfocus([FromRoute] Guid id)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }

    //    var fracfocus = await _context.Fracfocus.FindAsync(id);
    //    if (fracfocus == null)
    //    {
    //        return NotFound();
    //    }

    //    _context.Fracfocus.Remove(fracfocus);
    //    await _context.SaveChangesAsync();

    //    return Ok(fracfocus);
    //}

    //private bool FracfocusExists(Guid id)
    //{
    //    return _context.Fracfocus.Any(e => e.PKey == id);
    //}
    #endregion
}