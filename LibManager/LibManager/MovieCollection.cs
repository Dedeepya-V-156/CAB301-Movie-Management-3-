// Phase 2
// An implementation of MovieCollection ADT
// 2022


using System;

//A class that models a node of a binary search tree
//An instance of this class is a node in a binary search tree 
public class BTreeNode
{
	private IMovie movie; // movie
	private BTreeNode lchild; // reference to its left child 
	private BTreeNode rchild; // reference to its right child

	public BTreeNode(IMovie movie)
	{
		this.movie = movie;
		lchild = null;
		rchild = null;
	}

	public IMovie Movie
	{
		get { return movie; }
		set { movie = value; }
	}

	public BTreeNode LChild
	{
		get { return lchild; }
		set { lchild = value; }
	}

	public BTreeNode RChild
	{
		get { return rchild; }
		set { rchild = value; }
	}
}

// invariant: no duplicates in this movie collection
public class MovieCollection : IMovieCollection
{
	private BTreeNode root; // movies are stored in a binary search tree and the root of the binary search tree is 'root' 
	private int count; // the number of (different) movies currently stored in this movie collection 



	// get the number of movies in this movie colllection 
	// pre-condition: nil
	// post-condition: return the number of movies in this movie collection and this movie collection remains unchanged
	public int Number { get { return count; } }

	// constructor - create an object of MovieCollection object
	public MovieCollection()
	{
		root = null;
		count = 0;	
	}

	// Check if this movie collection is empty
	// Pre-condition: nil
	// Post-condition: return true if this movie collection is empty; otherwise, return false.
	public bool IsEmpty()
	{
		//To be completed
		return root == null;
	}

	// Insert a movie into this movie collection
	// Pre-condition: nil
	// Post-condition: the movie has been added into this movie collection and return true, if the movie is not in this movie collection; otherwise, the movie has not been added into this movie collection and return false.
	public bool Insert(IMovie movie)
	{
		//Check to see if this is the first movie inserted 
		if (root == null)
		{
			root = new BTreeNode(movie);
			count++;
			return true;
		}
		//Check to see if the movie is already in the Movie collection list
		else if (Search(movie))
		{
			//Console.WriteLine(movie.ToString() + " is already in the movie collecton");
			return false;

		}
		//Add movie if it's not in the movie collection
		else
		{
			Insert(movie, root);
			count++;
			//Console.WriteLine(movie.ToString() + " is added into the movie collection");
			return true;
		}

	}

	//a private method to insert a movie into its correct location 
	//Compares each movie title alphabetically
	//and place them in the correct spot in movie collection binary tree
	private void Insert(IMovie movie, BTreeNode ptr)
	{
		if (movie.CompareTo(ptr.Movie) < 0)
		{
			if (ptr.LChild == null)
				ptr.LChild = new BTreeNode(movie);
			else
				Insert(movie, ptr.LChild);
		}
		else
		{
			if (ptr.RChild == null)
				ptr.RChild = new BTreeNode(movie);
			else
				Insert(movie, ptr.RChild);
		}
	}

	// Delete a movie from this movie collection
	// Pre-condition: nil
	// Post-condition: the movie is removed out of this movie collection and return true, if it is in this movie collection; return false, if it is not in this movie collection
	public bool Delete(IMovie movie)
	{
		//search for the movie and its parent
		BTreeNode ptr = root;
		BTreeNode parent = null;
		while ((ptr != null) && (movie.CompareTo(ptr.Movie) != 0))
		{
			parent = ptr;
			if (movie.CompareTo(ptr.Movie) < 0)
				ptr = ptr.LChild;
			else
				ptr = ptr.RChild;
		}
		//if search is successful
		if (ptr != null)
		{
			//movie has two children
			if ((ptr.LChild != null) && (ptr.RChild != null))
			{
				//find the right-most node in left subtree of ptr
				if (ptr.LChild.RChild == null)
				{
					//copy the movie at left child to ptr 
					ptr.Movie = ptr.LChild.Movie;
					ptr.LChild = ptr.LChild.LChild;
					count--;
					//Console.WriteLine(movie.ToString() + " is deleted from this collection list");
					return true;
				}
				else
				{
					BTreeNode p = ptr.LChild;
					BTreeNode pp = ptr;
					while (p.RChild != null)
					{
						pp = p;
						p = p.RChild;
					}
					//copy the movie at p(right-most node) to ptr 
					ptr.Movie = p.Movie;
					pp.RChild = p.LChild;
					count--;
					//Console.WriteLine(movie.ToString() + " is deleted from this collection list");
					return true;

				}
			}
			//movie has one or no child
			else
			{
				BTreeNode c;
				if (ptr.LChild != null)
					c = ptr.LChild;
				else
					c = ptr.RChild;

				if (ptr == root)
				{
					//Remove the root
					root = c;
					count--;
					//Console.WriteLine(movie.ToString() + " is deleted from this collection list");
					return true;
				}

				else
				{
					if (ptr == parent.LChild)
					{
						//Remove the left node
						parent.LChild = c;
						count--;
						//Console.WriteLine(movie.ToString() + " is deleted from this collection list");
						return true;
					}
					else
					{
						//Remove the right node
						parent.RChild = c;
						count--;
						//Console.WriteLine(movie.ToString() + " is deleted from this collection list");
						return true;
					}
				}
			}
		}
		else
		{
			Console.WriteLine("Movie doesn't exists in the collection");
			return false;
		}
	}


	// Search for a movie in this movie collection
	// pre: nil
	// post: return true if the movie is in this movie collection;
	//	     otherwise, return false.
	public bool Search(IMovie movie)
	{
		//To be completed
		return Search(movie, root);
	}

	private bool Search(IMovie movie, BTreeNode root)
	{
		if (root != null)
		{
			if (movie.CompareTo(root.Movie) == 0)
				return true;
			else
				if (movie.CompareTo(root.Movie) < 0)
				return Search(movie, root.LChild);
			else
				return Search(movie, root.RChild);
		}
		else
			return false;
	}

	// Search for a movie by its title in this movie collection  
	// pre: nil
	// post: return the reference of the movie object if the movie is in this movie collection;
	//	     otherwise, return null.
	public IMovie Search(string movietitle)
	{
		//To be completed
		if (root != null)
		{
			if (movietitle.CompareTo(root.Movie.Title) == 0)
				return root.Movie;
			else
				if (movietitle.CompareTo(root.Movie.Title) < 0)

				return Search(movietitle, root.LChild); 
			else
				return Search(movietitle, root.RChild); 
		}
		else return null;
	}

	private IMovie Search(string movietitle, BTreeNode root)
	{
		if (root != null)
		{
			if (movietitle.CompareTo(root.Movie.Title) == 0)
				return root.Movie;
			else
				if (movietitle.CompareTo(root.Movie.Title) < 0)
				return Search(movietitle, root.LChild);
			else
				return Search(movietitle, root.RChild);
		}
		else return null;
	}




	// Store all the movies in this movie collection in an array in the dictionary order by their titles
	// Pre-condition: nil
	// Post-condition: return an array of movies that are stored in dictionary order by their titles
	public IMovie[] ToArray()
	{
		IMovie[] movies = new IMovie[Number];
		ToArray(root, movies, 0);
		return movies;
	}

	//run an In-Order traversal of the binary tree
	//Keep the correct index of the array
	//and store the value of the movie in the correct position
	private int ToArray(BTreeNode ptr, IMovie[] movies, int index)
	{
		if (ptr == null)
			return index;
		//visit the left child first
		if (ptr.LChild != null)
		{
			index = ToArray(ptr.LChild, movies, index);
		}
		//save the node value in movies array
		movies[index++] = ptr.Movie;
		//visit the right child 
		if (ptr.RChild != null)
		{
			index = ToArray(ptr.RChild, movies, index);
		}
		return index;

	}


	// Clear this movie collection
	// Pre-condotion: nil
	// Post-condition: all the movies have been removed from this movie collection 
	public void Clear()
	{
		//To be completed
		root = null;
		count = 0;
	}
}





