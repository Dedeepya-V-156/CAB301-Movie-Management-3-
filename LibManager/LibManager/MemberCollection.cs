//CAB301 assessment 1 - 2022
//The implementation of MemberCollection ADT
using System;
using System.Linq;




    public class MemberCollection : IMemberCollection
    {
        // Fields
        private int capacity;
        private int count;
        private Member[] members; //make sure members are sorted in dictionary order

        // Properties

        // get the capacity of this member colllection 
        // pre-condition: nil
        // post-condition: return the capacity of this member collection and this member collection remains unchanged
        public int Capacity { get { return capacity; } }

        // get the number of members in this member colllection 
        // pre-condition: nil
        // post-condition: return the number of members in this member collection and this member collection remains unchanged
        public int Number { get { return count; } }




        // Constructor - to create an object of member collection 
        // Pre-condition: capacity > 0
        // Post-condition: an object of this member collection class is created

        public MemberCollection(int capacity)
        {
            if (capacity > 0)
            {
                this.capacity = capacity;
                members = new Member[capacity];
                count = 0;
            }
        }

        // check if this member collection is full
        // Pre-condition: nil
        // Post-condition: return ture if this member collection is full; otherwise return false.
        public bool IsFull()
        {
            return count == capacity;
        }

        // check if this member collection is empty
        // Pre-condition: nil
        // Post-condition: return ture if this member collection is empty; otherwise return false.
        public bool IsEmpty()
        {
            return count == 0;
        }

        // Add a new member to this member collection
        // Pre-condition: this member collection is not full
        // Post-condition: a new member is added to the member collection and the members are sorted in ascending order by their full names;
        // No duplicate will be added into this the member collection
        public void Add(IMember member)
        {
            // To be implemented by students in Phase 1
            if (!IsFull())
            {
                if (count > 0)
                {
                    int pos = count - 1;
                    int j = 0;
                    while (j != 1)
                    {
                        j = member.CompareTo(members[pos]);

                        if (j == 1)
                        {
                            pos++;
                            break;
                        }
                        if (j == -1)
                        {
                            if (pos == 0)
                            {
                                break;
                            }
                            pos--;
                        }
                        if (j == 0)
                        {
                            Console.WriteLine("Duplicate member!");
                            return;
                        }
                    }
                    for (int i = count; i >= pos; i--)
                    {
                        if (i != pos)
                        {
                            members[i] = members[i - 1];
                        }
                        else
                        {
                            members[pos] = (Member)member;
                            count++;
                            return;
                        }
                    }
                }
                members[count] = (Member)member;
                count++;
                return;
            }
            Console.Write($"Members is full.");
        }

        // Remove a given member out of this member collection
        // Pre-condition: nil
        // Post-condition: the given member has been removed from this member collection, if the given meber was in the member collection
        public void Delete(IMember aMember)
        {
            // To be implemented by students in Phase 1
            if (!IsEmpty())
            {
                int pos = -1;
                int j = 0;
                int k = 0;
                double l = 0;
                double r = count - 1;
                while (l <= r)
                {
                    int m = Convert.ToInt16(Math.Floor((l + r) / 2));
                    if (aMember.LastName == members[m].LastName )
                    {
                        if (aMember.FirstName == members[m].FirstName)
                        {
                            Console.Write($"Member: {members[m].ToString()}, deleted.\n");
                            pos = m;
                        }
                        else if (aMember.FirstName[j] == members[m].FirstName[j])
                        {
                            j++;
                        }
                        else if (aMember.FirstName[j] < members[m].FirstName[j])
                        {
                            r = m - 1;
                        }
                        else
                        {
                            l = m + 1;
                        }
                    }
                    else if (aMember.LastName[k] == members[m].LastName[k])
                    {
                        k++;
                    }
                    else if (aMember.LastName[k] < members[m].LastName[k])
                    {
                        r = m - 1;
                    }
                    else
                    {
                        l = m + 1;
                    }

                    if (pos >= 0)
                    {
                        for (int i = pos; i < count-1; i++)
                        {
                            members[i] = members[i + 1]; // Currently i replace i with i+1, this is fine if the array
                            // is not full, 
                        }
                        members[count - 1] = null;
                        count--;
                        return;
                    }
                }
            }

            return;
        }

        // Search a given member in this member collection 
        // Pre-condition: nil
        // Post-condition: return true if this memeber is in the member collection; return false otherwise; member collection remains unchanged
        public bool Search(IMember member)
        {
            // To be implemented by students in Phase 1
            if (!IsEmpty())
            {
                int j = 0;
                int k = 0;
                double l = 0;
                double r = count - 1;
                while (l <= r)
                {
                    int m = Convert.ToInt16(Math.Floor((l + r) / 2));
                    if (member.LastName == members[m].LastName)
                    {
                        if (member.FirstName == members[m].FirstName)
                        {
                            Console.Write($"Found member: {members[m].ToString()}.\n");
                            return true;
                        }
                        else if (member.FirstName[j] == members[m].FirstName[j])
                        {
                            j++;
                        }
                        else if (member.FirstName[j] < members[m].FirstName[j])
                        {
                            r = m - 1;
                        }
                        else
                        {
                            l = m + 1;
                        }

                    }
                    else if (member.LastName[k] == members[m].LastName[k])
                    {
                        k++;
                    }
                    else if (member.LastName[k] < members[m].LastName[k])
                    {
                        r = m - 1;
                    }
                    else
                    {
                        l = m + 1;
                    }
                }
                Console.Write($"Unable to find member: {member.ToString()}.\n");
                return false;
            }

            return false;
        }
    //Emma: modified this method
    public IMember Find(IMember member)
    {
        // To be implemented by students in Phase 1
        if (!IsEmpty())
        {
            int j = 0;
            int k = 0;
            double l = 0;
            double r = count - 1;
            while (l <= r)
            {
                int m = Convert.ToInt16(Math.Floor((l + r) / 2));
                if (member.LastName == members[m].LastName)
                {
                    if (member.FirstName == members[m].FirstName)
                    {
                        Console.Write($"Found member: {members[m].ToString()}.\n");
                        return members[m];
                    }
                    else if (member.FirstName[j] == members[m].FirstName[j])
                    {
                        j++;
                    }
                    else if (member.FirstName[j] < members[m].FirstName[j])
                    {
                        r = m - 1;
                    }
                    else
                    {
                        l = m + 1;
                    }

                }
                else if (member.LastName[k] == members[m].LastName[k])
                {
                    k++;
                }
                else if (member.LastName[k] < members[m].LastName[k])
                {
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }
            Console.Write($"Unable to find member:" + member.FirstName + " " + member.LastName + ".\n");
            return null;
        }

        return null;
    }

    // Remove all the members in this member collection
    // Pre-condition: nil
    // Post-condition: no member in this member collection 
    public void Clear()
        {
            for (int i = 0; i < count; i++)
            {
                this.members[i] = null;
            }
            count = 0;
        }

        // Return a string containing the information about all the members in this member collection.
        // The information includes last name, first name and contact number in this order
        // Pre-condition: nil
        // Post-condition: a string containing the information about all the members in this member collection is returned
        public string ToString()
        {
            string s = "";
            for (int i = 0; i < count; i++)
                s = s + members[i].ToString() + "\n";
            return s;
        }

    }

