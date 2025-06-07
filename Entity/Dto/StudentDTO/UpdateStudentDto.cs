namespace Entity.Dto.StudentDTO
{
    public class UpdateStudentDto : BaseDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
