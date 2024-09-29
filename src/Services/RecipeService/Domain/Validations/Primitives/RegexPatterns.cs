using System.Text.RegularExpressions;

namespace Domain.Validations.Primitives;


public static class RegexPatterns
{
    public static readonly Regex Phone= new(@"^\+?\d{9,15}$");
    
    public static readonly Regex TelegramName = new("^@[A-Za-z0-9_]+$");
    
    public static readonly Regex FullName = new(@"^[a-zA-Zа-яА-Я0-9']+$");
    
    public static readonly Regex RecipeLink = new Regex(@"/recipes/recipe\.php\?rid=\d+$");
}