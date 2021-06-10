// Inventory.cs
// Defines the Inventory class.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace LacosteC968Task
{
	static class Inventory
	{
		public static BindingList<Part> AllParts = new BindingList<Part>();
		public static BindingList<Product> Products = new BindingList<Product>();

		static public void addProduct(Product prod1) 
		{
			Products.Add(prod1);
		}

		static public void removeProduct(int prodID)
        {
            try
            {
				Product target = Products.SingleOrDefault(p => p.ProductID == prodID);
				Products.Remove(target);
			}
            catch
            {
				MessageBox.Show("Could not locate product.");
            }

		}

		static public void lookupProduct(int prodID)
        {
			foreach(Product element in Products)
            {
				if (element.ProductID == prodID)
                {
					MessageBox.Show($"Product ID {prodID} is assigned to {element.Name}");
					
                }
            }
		}

		static public void updateProduct(int prodID, Product prod1)
        {
			Products[prodID] = prod1;
        }

		static public void addPart(Part part1)
        {
			AllParts.Add(part1);
        }

		static public void deletePart(Part part1)
        {
			AllParts.Remove(part1);
        }

		static public void lookupPart(int partID)
        {
			foreach (Part element in AllParts)
            {
				if (element.PartID == partID)
                {
					MessageBox.Show($"Located {element.Name} in Parts list.");
                }
            }
        }

		static public void updatePart(int prodID, Part part1)
        {
			AllParts[prodID] = part1;
        }
	}
}
