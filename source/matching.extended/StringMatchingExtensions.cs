using System.Text.RegularExpressions;

namespace code.matching.extended
{
  public static class StringMatchingExtensions
  {
    public static MatchingExtensionPoint<string> phone_number(this MatchingExtensionPoint<string> extension)
    {
      return MatchingExtensionPoint<string>.create_from(x => Regex.IsMatch(x,
        @"(?:(?:(\s*\(?([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*)|([2-9]1[02-9]|[2‌​-9][02-8]1|[2-9][02-8][02-9]))\)?\s*(?:[.-]\s*)?)([2-9]1[02-9]|[2-9][02-9]1|[2-9]‌​[02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})"));
    }

	public static MatchingExtensionPoint<string> social_security_number(this MatchingExtensionPoint<string> extension)
	{
	  return MatchingExtensionPoint<string>.create_from(x => Regex.IsMatch(x, @"^\d{3}-?\d{2}-?\d{4}$"));
	}

	public static MatchingExtensionPoint<string> email_address(this MatchingExtensionPoint<string> extension)
	{
	  return MatchingExtensionPoint<string>.create_from(x => Regex.IsMatch(x, @"^\S+@\S+$"));
	}

	public static MatchingExtensionPoint<string> password(this MatchingExtensionPoint<string> extension)
	{
	  return MatchingExtensionPoint<string>.create_from(x => Regex.IsMatch(x, @"^.*(?=.{4,10})(?=.*\d)(?=.*[a-zA-Z]).*$"));
	}

	public static MatchingExtensionPoint<string> zip_code(this MatchingExtensionPoint<string> extension)
    {
      return MatchingExtensionPoint<string>.create_from(x => Regex.IsMatch(x, @"^\d{5}(?:[-\s]\d{4})?$"));
    }

    public static MatchingExtensionPoint<string> is_empty(this MatchingExtensionPoint<string> extension)
    {
      return MatchingExtensionPoint<string>.create_from(x => x == string.Empty);
    }

    public static MatchingExtensionPoint<string> is_whitespace(this MatchingExtensionPoint<string> extension)
    {
      return MatchingExtensionPoint<string>.create_from(x => x.Trim() == string.Empty);
    }

    public static MatchingExtensionPoint<string> is_null_or_empty(this MatchingExtensionPoint<string> extension)
    {
      return extension.is_null().or(x => x.is_empty());
    }

    public static MatchingExtensionPoint<string> is_null_or_whitespace(this MatchingExtensionPoint<string> extension)
    {
      return extension.is_null().or(x => x.is_whitespace());
    }
  }
} 