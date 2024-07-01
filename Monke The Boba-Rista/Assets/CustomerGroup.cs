using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CustomerGroup : MonoBehaviour
    {

        // randomizing customer groups

        //single(1 person/ drink)

        //couple(2 people/ 2 drinks)

        //Boba Fiends(4 people/4 drinks)

        
        public GameObject customerGroupPreFab;
        //public BobaOrder bobaOrder;

       
            private int[] groupCountRand = { 1, 2, 4 };
            public int groupCount;
            private string groupName;
            public List<BobaOrder> bobaOrders;

            public CustomerGroup()
            {
                groupCount = setGroupCount();
                groupName = setGroupName(groupCount);
                bobaOrders = setBobaOrders(groupCount);
            }
            private int setGroupCount()
            {
                int count = Random.Range(0, groupCountRand.Length);
                int groupCount = groupCountRand[count];
                return groupCount;
            }

            private string setGroupName(int groupCount)
            {

                //change groupcount to ENUM
                string name = "";
                if (groupCount == 1)
                {
                    name = "Single Group";
                }
                else if (groupCount == 2)
                {
                    name = "Couple Group";

                }
                else if (groupCount == 4)
                {
                    name = "Boba Fiends Group";

                }

                return name;

            }

            private List<BobaOrder> setBobaOrders(int groupCount)
            {
                List<BobaOrder> bobaList = new List<BobaOrder>();
                for (int i = 0; i < groupCount; i++)
                {
                    BobaOrder order = new BobaOrder();
                    bobaList.Add(order);
                }

                return bobaList;
            }

            public string displayCustomer()
            {
                string customer = "Group Count: " + groupCount + ", Name: " + groupName + ", Boba Orders: ";

                for (int i = 0; i < bobaOrders.Count; i++)
                {
                    customer += bobaOrders[i].displayOrder() + ", ";
                }

                return customer;
            }
        }
