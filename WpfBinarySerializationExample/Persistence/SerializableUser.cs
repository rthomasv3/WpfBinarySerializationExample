using System;

namespace CodeCompendium.WpfBinarySerializationExample.Persistence
{
   /// <summary>
   /// Serializable model used to represent user information.
   /// </summary>
   [Serializable]
   public sealed class SerializableUser
   {
      #region Fields

      private string _userName;
      private string _email;
      private DateTime _lastLogin;

      #endregion

      #region Constructor

      /// <summary>
      /// Creates a new instance of the <see cref="SerializableUser"/> class.
      /// </summary>
      public SerializableUser()
      {
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
