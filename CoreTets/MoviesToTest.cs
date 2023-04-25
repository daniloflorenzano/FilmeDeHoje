using Domain.Entities;

namespace xUnitTests.Core;

public static class MoviesToTest
{
    public static List<Movie> All()
    {
        return new List<Movie>
            {
                new("I See You", "Strange occurrences plague a small-town detective and his family as he investigates the disappearance of a boy.", "Mystery & thriller", 2019, 73, 75, ""),
                new("Luther: The Fallen Sun", "In Luther: The Fallen Sun -- an epic continuation of the award-winning television saga reimagined for film -- a gruesome serial killer is terrorizing London while brilliant but disgraced detective John Luther (Idris Elba) sits behind bars. Haunted by his failure to capture the cyber psychopath who now taunts him, Luther decides to break out of prison to finish the job by any means necessary.", "Crime, Drama, Mystery & thriller", 2023, 85, 67, ""),
                new("The Last Thing He Wanted", "A reporter stumbles upon a story involving a former CIA operative and a senator who may have been involved in a secret arms deal.", "Crime, Drama, Mystery & thriller", 2020, 13, 5, ""),
                new("RRR", "The story of freedom fighters Komaram Bheem and Alluri Sitarama Raju.", "Action, Drama", 2022, 94, 95, ""),
                new("The Gentlemen", "An American expat tries to sell off his highly profitable marijuana empire in London, triggering plots, schemes, bribery and blackmail in an attempt to steal his domain out from under him.", "Action, Comedy, Crime", 2020, 84, 75, ""),
                new("The Godfather", "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "Crime", 1972, 98, 99, ""),
                new("The Shawshank Redemption", "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "Drama", 1994, 97, 91, ""),
                new("The Dark Knight", "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.", "Action", 2008, 94, 90, ""),
                new("Pulp Fiction", "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "Crime", 1994, 96, 94, ""),
                new("Forrest Gump", "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other history unfold through the perspective of an Alabama man with an IQ of 75.", "Drama", 1994, 95, 82, ""),
                new("The Matrix", "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "Sci-Fi", 1999, 85, 73, ""),
                new("The Silence of the Lambs", "A young F.B.I. cadet must receive the help of an incarcerated and manipulative cannibal killer to help catch another serial killer, a madman who skins his victims.", "Thriller", 1991, 95, 96, ""),
            };
    }
}