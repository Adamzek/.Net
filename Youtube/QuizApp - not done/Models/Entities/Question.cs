namespace QuizApp.Models.Entities;

public record Question
{
    public Guid Id { get; init; }
    public required string Text { get; init; }

    //Answers
    public required List<Answer> Answers { get; init; }
    public required Guid CorrectAnswer { get; init; }

}
