using Microsoft.AspNetCore.Mvc;
using Rapid_Rescue.DTO.RequestModel;
using Rapid_Rescue.DTO.ResponseModel;
using Rapid_Rescue.Entities;
using System.Net.Http.Headers;

namespace Rapid_Rescue.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : Controller
    {
        private readonly RapidRescueDbContext _context;
        public HomeController(RapidRescueDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("firstaidinstruction")]
        public IActionResult Index()
        {
            List<FirstAidInstruction> firstAids = _context.FirstAidInstructions.ToList();
            List<FirstAidResponse> data = FirstAidResponse.BuildProductList(firstAids);
            return Ok(firstAids);
        }

        [HttpGet]
        [Route("imageGallery")]
        public IActionResult IndexImage()
        {
            List<ImageGallery> imageGalleries = _context.ImageGalleries.ToList();


            return Ok(imageGalleries);
        }

        [HttpDelete]
        [Route("deleteimageGallery")]
        public IActionResult DeleteImageGallery(int id)
        {
            try
            {
                ImageGallery item = _context.ImageGalleries.Find(id);
                if (item == null)
                {
                    throw new Exception("ContactUs null");
                };
                _context.ImageGalleries.Remove(item);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("contactusQuerys")]
        public IActionResult ContactusQuery()
        {
            List<ContactUsQuery> contactUsQueries = _context.ContactUsQueries.ToList();

            return Ok(contactUsQueries);
        }

        [HttpPost]
        [Route("createContactQuery")]
        public IActionResult CreateContactQuery(CreateContactQuery model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.Values.SelectMany(v => v.Errors)
                        .Select(v => v.ErrorMessage).First());
                }
                ContactUsQuery data = new ContactUsQuery
                {
                    Name = model.name,
                    Email = model.email,
                    ContactNumber = model.contactNumber,
                    Message = model.messages,
                   
                };
                _context.ContactUsQueries.Add(data);
                _context.SaveChanges();


                return Created($"find?id={data.QueryId}", new ContactUsQueryResponse(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteContactQuery")]
        public IActionResult DeleteContactQuery(int id)
        {
            try
            {
                ContactUsQuery item = _context.ContactUsQueries.Find(id);
                if (item == null)
                {
                    throw new Exception("ContactUs null");
                };
                _context.ContactUsQueries.Remove(item);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
