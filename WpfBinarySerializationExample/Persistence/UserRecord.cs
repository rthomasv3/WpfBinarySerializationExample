using System;

namespace CodeCompendium.WpfBinarySerializationExample.Persistence
{
   /// <summary>
   /// Record class used to represent a user.
   /// </summary>
   public sealed class UserRecord
   {
      /// <summary>
      /// Gets or sets user name.
      /// </summary>
      public string UserName { get; set; }

      /// <summary>
      /// Gets or sets email.
      /// </summary>
      public string Email { get; set; }

      /// <summary>
      /// Gets or sets the last login date.
      /// </summary>
      public DateTime LastLogin { get; set; }
   }
}
