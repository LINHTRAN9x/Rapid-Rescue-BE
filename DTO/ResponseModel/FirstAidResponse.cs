using Rapid_Rescue.Entities;

namespace Rapid_Rescue.DTO.ResponseModel
{
    public class FirstAidResponse
    {

        public FirstAidResponse(FirstAidInstruction firstaid)
        {
            instructionId = firstaid.InstructionId;
            title = firstaid.Title;
            description = firstaid.Description;
            content = firstaid.Content;
            imageUrl = firstaid.ImageUrl;
        }
        public int instructionId { get; set; }

        public string? title { get; set; }

        public string? description { get; set; }

        public string? content { get; set; }

        public string? imageUrl { get; set; }

        public static List<FirstAidResponse> BuildProductList(List<FirstAidInstruction> firstair)
        {

            List<FirstAidResponse> responseList = new List<FirstAidResponse>();


            foreach (var firstaid in firstair)
            {

                responseList.Add(new FirstAidResponse(firstaid));
            }


            return responseList;
        }
    }
}
