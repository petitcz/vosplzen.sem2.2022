namespace vosplzen.sem2h1.Data.Dto
{
    public class StudentResponseDto
    {
        public int Success { get; set; }
        public int Failed { get; set; }

        public List<StudentResponseIdPairDto> Result { get; set; }

    }
}
