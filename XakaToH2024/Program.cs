using System;
using System.Collections.Generic;

namespace ControlObjectsManagementSystem
{
    class ControlObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ControlDate { get; set; }
    }

    class ControlObjectsManager
    {
        private List<ControlObject> controlObjects;

        public ControlObjectsManager()
        {
            controlObjects = new List<ControlObject>();
        }

        public void AddControlObject(ControlObject obj)
        {
            controlObjects.Add(obj);
        }

        public void EditControlObject(string name, ControlObject newObj)
        {
            int index = controlObjects.FindIndex(obj => obj.Name == name);
            if (index != -1)
            {
                controlObjects[index] = newObj;
            }
            else
            {
                Console.WriteLine("Object not found.");
            }
        }

        public void RemoveControlObject(string name)
        {
            controlObjects.RemoveAll(obj => obj.Name == name);
        }

        public void ShowAllControlObjects()
        {
            foreach (var obj in controlObjects)
            {
                Console.WriteLine($"Name: {obj.Name}, Description: {obj.Description}, Control Date: {obj.ControlDate}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ControlObjectsManager manager = new ControlObjectsManager();

            ControlObject obj1 = new ControlObject
            {
                Name = "Object 1",
                Description = "Description of Object 1",
                ControlDate = DateTime.Now.AddDays(7)
            };
            manager.AddControlObject(obj1);

            ControlObject newObj1 = new ControlObject
            {
                Name = "Object 1",
                Description = "Updated description of Object 1",
                ControlDate = DateTime.Now.AddDays(10)
            };
            manager.EditControlObject("Object 1", newObj1);

            manager.RemoveControlObject("Object 1");

            manager.ShowAllControlObjects();
        }
    }
}
