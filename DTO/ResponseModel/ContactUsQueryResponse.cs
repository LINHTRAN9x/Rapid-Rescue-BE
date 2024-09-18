using Rapid_Rescue.Entities;

namespace Rapid_Rescue.DTO.ResponseModel
{
    public class ContactUsQueryResponse
    {

        public ContactUsQueryResponse(ContactUsQuery item)
        {
            queryId = item.QueryId;
            name = item.Name;
            email = item.Email;
            contactNumber = item.ContactNumber;
            message = item.Message;
           
        }

        public int queryId { get; set; }

        public string? name { get; set; }

        public string? email { get; set; }

        public string? contactNumber { get; set; }

        public string? message { get; set; }
 

        public static List<ContactUsQueryResponse> BuildProductList(List<ContactUsQuery> products)
        {

            List<ContactUsQueryResponse> responseList = new List<ContactUsQueryResponse>();


            foreach (var product in products)
            {

                responseList.Add(new ContactUsQueryResponse(product));
            }


            return responseList;
        }
    }
}
