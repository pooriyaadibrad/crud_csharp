using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp21
{
    public class laptop
    {
        public int id { get; set; }
        public string model { get; set; }
        public string cpu { get; set; }
        public double price { get; set; }
       public db db1=new db();
        public bool register(laptop laptop)
        {

            if (!exsit(laptop))
            {
                db1.laptops.Add(laptop);
                db1.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
           
        }
        public bool exsit(laptop laptop)
        {
           var a=db1.laptops.Where(i=>i.model==laptop.model).ToList();
            if (a.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public laptop reedbyid(int id)
        {
           return db1.laptops.Where(i => i.id == id).FirstOrDefault();
        }
        public List<laptop> reedbymodel(string s)
        {
            return db1.laptops.Where(i=>i.model.Contains(s)).ToList();
        }
        public List<laptop> reedbyall()
        {
            return db1.laptops.ToList();
        }
        public void delete(int id)
        {
            laptop laptop= reedbyid(id);
            db1.laptops.Remove(laptop);
            db1.SaveChanges();
        }
        public void update(int id, laptop laptop)
        {
          var lap=db1.laptops.Where(i=>i.id==id).FirstOrDefault();
            lap.model=laptop.model;
            lap.cpu = laptop.cpu;
            lap.price=laptop.price;
            db1.SaveChanges();
            
        }
        
    }
}
