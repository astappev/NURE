#include <iostream>
using namespace std;

struct Tree
{
   int key;
   Tree *left;
   Tree *right;
};

Tree *Insert (Tree **theTree, int theKey)
{
   Tree **node= theTree;
   while (*node && theKey != (*node)->key)
      if (theKey < (*node)->key)
         node= &((*node)->left);
      else
         node= &((*node)->right);
   if (!(*node))
   {
      *node= new Tree;
      (*node)->key= theKey;
      (*node)->right= (*node)->left= NULL;
   }
   return *theTree;
}
int MaxValue(Tree *root)
{
    if (root->right != NULL) {
        return MaxValue(root->right);
    } else {
        return root->key;
    }
}
int MinValue(Tree *root)
{
    if (root->left != NULL) {
        return MinValue(root->left);
    } else {
        return root->key;
    }
}
int rightmost(Tree *root)
{
	while (root->right != NULL)
		root = root->right;
	return root->key;
}
Tree *del_tree(Tree *root, int val)
{
	if (NULL == root) return NULL;
	else if (root->key == val) {
		if (NULL == root->left && NULL == root->right) {
			free(root);
			return NULL;
		}
		else if (NULL == root->right && root->left != NULL) {
			Tree *temp = root->left;
			free(root);
			return temp;
		}
		else if (NULL == root->left && root->right != NULL) {
			Tree *temp = root->right;
			free(root);
			return temp;
		}
		root->key = rightmost(root->left);
		root->left = del_tree(root->left, root->key);
		return root;
	}
	else if (val < root->key) {
		root->left = del_tree(root->left, val);
		return root;
	}
	else if (val > root->key) {
		root->right = del_tree(root->right, val);
		return root;
	}
	return root;
}
int main()
{
   Tree *tree= NULL;
   freopen("input.txt", "r", stdin);
	//freopen("output.txt", "w", stdout);
	int a=1;
	while (a != 0)
	{
		cin>>a;
		if (a == 0) break;
			Insert(&tree, a);
	}
   //Print(tree);
	//cout<<MaxValue(tree);
	tree = del_tree(tree, MaxValue(tree));
	cout<<MaxValue(tree);
   //cout<<Max2Value(tree, 0);
   return 0;
}