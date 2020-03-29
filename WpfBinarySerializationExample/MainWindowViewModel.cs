using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Input;
using CodeCompendium.BinarySerialization;
using CodeCompendium.WpfBinarySerializationExample.Models;
using CodeCompendium.WpfBinarySerializationExample.Persistence;
using Microsoft.Win32;

namespace CodeCompendium.WpfBinarySerializationExample
{
   /// <summary>
   /// View model for the application <see cref="MainWindow"/>.
   /// </summary>
   public sealed class MainWindowViewModel : NotifyPropertyChanged
   {
      #region Fields

      private const string _serializableBinFilter = "Serializable File|*.sbin";
      private const string _userBinFilter = "User Binary File|*.ubin";

      private readonly BinarySerializer _binarySerializer;

      private User _userFromSerializable;
      private User _userFromRecord;
      private long _serializableUserSaveSize;
      private long _userRecordSaveSize;

      private readonly ICommand _saveSerializableUserCommand;
      private readonly ICommand _clearSerializableUserCommand;
      private readonly ICommand _loadSerializableUserCommand;
      private readonly ICommand _saveUserRecordCommand;
      private readonly ICommand _clearUserRecordCommand;
      private readonly ICommand _loadUserRecordCommand;

      #endregion

      #region Constructor

      /// <summary>
      /// Creates a new instance of the <see cref="MainWindowViewModel"/> class.
      /// </summary>
      public MainWindowViewModel(BinarySerializer binarySerializer)
      {
         _binarySerializer = binarySerializer ?? throw new ArgumentNullException(nameof(binarySerializer));

         _userFromSerializable = new User("Some User Name", "someuser@test.com", DateTime.Now);
         _userFromRecord = new User("Some User Name", "someuser@test.com", DateTime.Now);

         _saveSerializableUserCommand = new RelayCommand(SaveSerializableUser);
         _clearSerializableUserCommand = new RelayCommand(ClearSerializableUser);
         _loadSerializableUserCommand = new RelayCommand(LoadSerializableUser);
         _saveUserRecordCommand = new RelayCommand(SaveRecordUser);
         _clearUserRecordCommand = new RelayCommand(ClearRecordUser);
         _loadUserRecordCommand = new RelayCommand(LoadRecordUser);
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the serializable user name.
      /// </summary>
      public string SerializableUserName
      {
         get { return _userFromSerializable.UserName; }
         set
         {
            _userFromSerializable.UserName = value;
            OnPropertyChanged();
         }
      }

      /// <summary>
      /// Gets or sets the serializable user email.
      /// </summary>
      public string SerializableUserEmail
      {
         get { return _userFromSerializable.Email; }
         set
         {
            _userFromSerializable.Email = value;
            OnPropertyChanged();
         }
      }

      /// <summary>
      /// Gets or sets the serializable user last login date.
      /// </summary>
      public DateTime SerializableUserLastLogin
      {
         get { return _userFromSerializable.LastLogin; }
         set
         {
            _userFromSerializable.LastLogin = value;
            OnPropertyChanged();
         }
      }

      /// <summary>
      /// Gets or sets the record user name.
      /// </summary>
      public string RecordUserName
      {
         get { return _userFromRecord.UserName; }
         set
         {
            _userFromRecord.UserName = value;
            OnPropertyChanged();
         }
      }

      /// <summary>
      /// Gets or sets the record user email.
      /// </summary>
      public string RecordUserEmail
      {
         get { return _userFromRecord.Email; }
         set
         {
            _userFromRecord.Email = value;
            OnPropertyChanged();
         }
      }

      /// <summary>
      /// Gets or sets the record user last login date.
      /// </summary>
      public DateTime RecordUserLastLogin
      {
         get { return _userFromRecord.LastLogin; }
         set
         {
            _userFromRecord.LastLogin = value;
            OnPropertyChanged();
         }
      }

      /// <summary>
      /// Gets the last serializable user save size.
      /// </summary>
      public long SerializableUserSaveSize
      {
         get { return _serializableUserSaveSize; }
      }

      /// <summary>
      /// Gets the last user record save size.
      /// </summary>
      public long RecordUserSaveSize
      {
         get { return _userRecordSaveSize; }
      }

      /// <summary>
      /// Gets the save serializable user command.
      /// </summary>
      public ICommand SaveSerializableUserCommand
      {
         get { return _saveSerializableUserCommand; }
      }

      /// <summary>
      /// Gets the clear serializable user command.
      /// </summary>
      public ICommand ClearSerializableUserCommand
      {
         get { return _clearSerializableUserCommand; }
      }

      /// <summary>
      /// Gets the load serializable user command.
      /// </summary>
      public ICommand LoadSerializableUserCommand
      {
         get { return _loadSerializableUserCommand; }
      }

      /// <summary>
      /// Gets the save user record command.
      /// </summary>
      public ICommand SaveRecordUserCommand
      {
         get { return _saveUserRecordCommand; }
      }

      /// <summary>
      /// Gets the clear user record command.
      /// </summary>
      public ICommand ClearRecordUserCommand
      {
         get { return _clearUserRecordCommand; }
      }

      /// <summary>
      /// Gets the load user record command.
      /// </summary>
      public ICommand LoadRecordUserCommand
      {
         get { return _loadUserRecordCommand; }
      }

      #endregion

      #region Private Methods

      private void SaveSerializableUser()
      {
         SaveFileDialog saveDialog = new SaveFileDialog();
         saveDialog.Filter = _serializableBinFilter;

         if (saveDialog.ShowDialog() == true)
         {
            SerializableUser serializableUser = new SerializableUser()
            {
               UserName = _userFromSerializable.UserName,
               Email = _userFromSerializable.Email,
               LastLogin = _userFromSerializable.LastLogin,
            };

            using (FileStream fileStream = new FileStream(saveDialog.FileName, FileMode.OpenOrCreate))
            {
               BinaryFormatter binaryFormatter = new BinaryFormatter();
               binaryFormatter.Serialize(fileStream, serializableUser);

               _serializableUserSaveSize = fileStream.Length;
               OnPropertyChanged(nameof(SerializableUserSaveSize));
            }
         }
      }

      private void ClearSerializableUser()
      {
         _userFromSerializable.UserName = String.Empty;
         _userFromSerializable.Email = String.Empty;
         _userFromSerializable.LastLogin = new DateTime();

         OnPropertyChanged(nameof(SerializableUserName));
         OnPropertyChanged(nameof(SerializableUserEmail));
         OnPropertyChanged(nameof(SerializableUserLastLogin));
      }

      private void LoadSerializableUser()
      {
         OpenFileDialog openDialog = new OpenFileDialog();
         openDialog.Filter = _serializableBinFilter;

         if (openDialog.ShowDialog() == true)
         {
            using (FileStream fileStream = new FileStream(openDialog.FileName, FileMode.Open))
            {
               BinaryFormatter binaryFormatter = new BinaryFormatter();
               SerializableUser serializableUser = binaryFormatter.Deserialize(fileStream) as SerializableUser;

               _userFromSerializable = new User(serializableUser);

               OnPropertyChanged(nameof(SerializableUserName));
               OnPropertyChanged(nameof(SerializableUserEmail));
               OnPropertyChanged(nameof(SerializableUserLastLogin));

               _serializableUserSaveSize = fileStream.Length;
               OnPropertyChanged(nameof(SerializableUserSaveSize));
            }
         }
      }

      private void SaveRecordUser()
      {
         SaveFileDialog saveDialog = new SaveFileDialog();
         saveDialog.Filter = _userBinFilter;

         if (saveDialog.ShowDialog() == true)
         {
            UserRecord userRecord = new UserRecord()
            {
               UserName = _userFromRecord.UserName,
               Email = _userFromRecord.Email,
               LastLogin = _userFromRecord.LastLogin,
            };

            byte[] userBytes = BinarySerializer.Serialize(userRecord);
            File.WriteAllBytes(saveDialog.FileName, userBytes);

            _userRecordSaveSize = userBytes.Length;
            OnPropertyChanged(nameof(RecordUserSaveSize));
         }
      }

      private void ClearRecordUser()
      {
         _userFromRecord.UserName = String.Empty;
         _userFromRecord.Email = String.Empty;
         _userFromRecord.LastLogin = new DateTime();

         OnPropertyChanged(nameof(RecordUserName));
         OnPropertyChanged(nameof(RecordUserEmail));
         OnPropertyChanged(nameof(RecordUserLastLogin));
      }

      private void LoadRecordUser()
      {
         OpenFileDialog openDialog = new OpenFileDialog();
         openDialog.Filter = _userBinFilter;

         if (openDialog.ShowDialog() == true)
         {
            byte[] userBytes = File.ReadAllBytes(openDialog.FileName);
            UserRecord userRecord = BinarySerializer.Deserialize<UserRecord>(userBytes);

            _userFromRecord = new User(userRecord);

            OnPropertyChanged(nameof(RecordUserName));
            OnPropertyChanged(nameof(RecordUserEmail));
            OnPropertyChanged(nameof(RecordUserLastLogin));

            _userRecordSaveSize = userBytes.Length;
            OnPropertyChanged(nameof(RecordUserSaveSize));
         }
      }

      #endregion
   }
}
