using System;
using CodeCompendium.WpfBinarySerializationExample.Persistence;

namespace CodeCompendium.WpfBinarySerializationExample.Models
{
   /// <summary>
   /// Model class used to represent a user.
   /// </summary>
   public sealed class User
   {
      #region Fields

      private string _userName;
      private string _email;
      private DateTime _lastLogin;

      #endregion

      #region Constructors

      /// <summary>
      /// Creates a new instance of the <see cref="User"/> class.
      /// </summary>
      public User(string username, string email, DateTime lastLogin)
      {
         _userName = username;
         _email = email;
         _lastLogin = lastLogin;
      }

      /// <summary>
      /// Creates a new instance of the <see cref="User"/> class based on the <paramref name="serializableUser"/>.
      /// </summary>
      public User(SerializableUser serializableUser)
      {
         if (serializableUser == null)
         {
            throw new ArgumentNullException(nameof(serializableUser));
         }

         _userName = serializableUser.UserName;
         _email = serializableUser.Email;
         _lastLogin = serializableUser.LastLogin;
      }

      /// <summary>
      /// Creates a new instance of the <see cref="User"/> class based on the <paramref name="userRecord"/>.
      /// </summary>
      public User(UserRecord userRecord)
      {
         if (userRecord == null)
         {
            throw new ArgumentNullException(nameof(userRecord));
         }

         _userName = userRecord.UserName;
         _email = userRecord.Email;
         _lastLogin = userRecord.LastLogin;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets user name.
      /// </summary>
      public string UserName
      {
         get { return _userName; }
         set { _userName = value; }
      }

      /// <summary>
      /// Gets or sets email.
      /// </summary>
      public string Email
      {
         get { return _email; }
         set { _email = value; }
      }

      /// <summary>
      /// Gets or sets the last login date.
      /// </summary>
      public DateTime LastLogin
      {
         get { return _lastLogin; }
         set { _lastLogin = value; }
      }

      #endregion
   }
}
