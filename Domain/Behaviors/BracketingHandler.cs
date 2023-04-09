using Domain.Entities;

namespace Domain.Behaviors
{
    public sealed class BracketingHandler
    {
        public (List<Bracketing>, List<Bracketing>) CreateBracket(List<Movie> movies)
        {
            var half = movies.Count / 2;

            var leftGroup = movies.Take(half).ToList();
            var rightGroup = movies.Skip(half).ToList();

            var leftBrackets = new List<Bracketing>();

            for (int i = 0; i < leftGroup.Count; i+=2)
            {
                var bracket = new Bracketing(leftGroup[i], leftGroup[i + 1]);
                leftBrackets.Add(bracket);
            }

            var rightBrackets = new List<Bracketing>();

            for (int i = 0; i < rightGroup.Count; i += 2)
            {
                //var bracket = new Bracketing(rightGroup[i], rightGroup[i + 1]);
                var leftMovie = rightGroup[0];
                Movie? rightMovie = null;

                if (i + 1 < rightGroup.Count)
                    rightMovie = rightGroup[i + 1];

                var bracket = new Bracketing(leftMovie, rightMovie);
                rightBrackets.Add(bracket);
            }
            
            return (leftBrackets, rightBrackets);
        }
    }
}
