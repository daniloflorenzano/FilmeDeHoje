namespace Domain.Entities
{
    public sealed class Bracketing
    {
        public Movie MovieLeft { get; }
        public Movie? MovieRigth { get; }

        public Bracketing(Movie movieLeft, Movie? movieRigth = null)
        {
            MovieLeft = movieLeft;
            MovieRigth = movieRigth;
        }
    }
}
