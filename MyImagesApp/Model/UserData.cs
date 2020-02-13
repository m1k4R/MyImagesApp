using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyImagesApp.Model
{
    public class UserData
    {
        private string fileName = "../../Users.xml";

        private static UserData _instance;

        public static UserData Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserData();

                return _instance;
            }
        }

        public void AddUser(User user)
        {
            if (!File.Exists(fileName))
            {
                XDocument xmlDocument = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("Users",
                        new XElement("User",
                            new XElement("Username", user.Username),
                            new XElement("Password", user.Password))));

                xmlDocument.Save(fileName); 
            }
            else
            {
                try
                {
                    FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    XDocument xmlDocument = XDocument.Load(stream);

                    XElement users = xmlDocument.Element("Users");

                    users.Add(new XElement("User",
                                  new XElement("Username", user.Username),
                                  new XElement("Password", user.Password)));

                    xmlDocument.Save(fileName);
                }
                catch { }
            }
        }

        public bool CheckIfUserExists(string username)
        {
            bool retVal = false;

            if (File.Exists(fileName))
            {
                XDocument xmlDocument = XDocument.Load(fileName);

                retVal = (from user in xmlDocument.Root.Elements("User")
                          where user.Element("Username").Value.ToString().ToLower().Equals(username.ToLower())
                          select user).Any();

                return retVal;
            }
            else
            {
                return retVal;
            }
        }

        public bool LoginUser(string username, string password)
        {
            bool retVal = false;

            if (File.Exists(fileName))
            {
                XDocument xmlDocument = XDocument.Load(fileName);

                retVal = (from user in xmlDocument.Root.Elements("User")
                          where (user.Element("Username").Value.ToString().ToLower().Equals(username.ToLower()) && user.Element("Password").Value.ToString().Equals(password))
                          select user).Any();

                return retVal;
            }
            else
            {
                return retVal;
            }
        }

        public User GetUser(string username)
        {
            if (File.Exists(fileName))
            {
                FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XDocument xmlDocument = XDocument.Load(stream);
                IEnumerable<User> users = xmlDocument.Root.Elements("User").Where(x => x.Element("Username").Value.ToLower().Equals(username.ToLower())).Select(userFind => new User
                {
                    Username = userFind.Element("Username").Value,
                    Password = userFind.Element("Password").Value

                }).ToList();

                User user = users.First(x => x.Username.ToLower().Equals(username.ToLower()));

                return user;
            }
            else
            {
                return null;
            }
        }

        public void EditUser(User user, string oldUsername)
        {
            if (File.Exists(fileName))
            {
                XDocument xmlDocument = XDocument.Load(fileName);

                xmlDocument.Element("Users").Elements("User")
                                                .Where(x => x.Element("Username").Value == oldUsername.ToString()).FirstOrDefault()
                                                .SetElementValue("Username", user.Username);
                xmlDocument.Element("Users").Elements("User")
                                                .Where(x => x.Element("Username").Value == user.Username.ToString()).FirstOrDefault()
                                                .SetElementValue("Password", user.Password);

                xmlDocument.Save(fileName);
            }
        }

        public void AddUserImage(User currentUser, MyImage image)
        {
            if (File.Exists(fileName))
            {
                FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XDocument xmlDocument = XDocument.Load(stream);

                IEnumerable<XElement> users = xmlDocument.Root.Elements("User").Where(x => x.Element("Username").Value.ToLower().Equals(currentUser.Username.ToLower()));
                XElement user = users.First();

                user.Add(new XElement("Image",
                              new XElement("Title", image.Title),
                              new XElement("Description", image.Description),
                              new XElement("Date", image.Date),
                              new XElement("Path", image.Path)));

                xmlDocument.Save(fileName);
            }
        }

        public IEnumerable<MyImage> GetUserImages(User currentUser)
        {
            if (File.Exists(fileName))
            {
                FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XDocument xmlDocument = XDocument.Load(stream);

                IEnumerable<XElement> users = xmlDocument.Root.Elements("User").Where(x => x.Element("Username").Value.ToLower().Equals(currentUser.Username.ToLower()));
                XElement user = users.First();

                IEnumerable<MyImage> images = user.Elements("Image").Select(img => new MyImage
                {
                    Title = img.Element("Title").Value,
                    Description = img.Element("Description").Value,
                    Date = img.Element("Date").Value,
                    Path = img.Element("Path").Value

                }).ToList();
                

                return images;
            }
            else
            {
                return null;
            }
        }

    }
}
