/*
InteracticeGraphics.cpp : Defines the entry point for the console application.
Author: Monish Vihari Vappangi
Description: Invokes a 2D drawing canvas which allows users to draw the following objects in different colors, sizes and width:
			 1.Point   	 2.Line   	 3.Triangle  	 4.Quadrilateral   	5.Polygon
*/

#include "stdafx.h"
#include <GL/glut.h>
#include <iostream>
using namespace std;

struct vertex
{
	float coordinate[2];
	float clr[3];
	float sz;
	float pSz;
	float lWth;
	int obj;
	int chk;
	struct vertex *next;
};

float canvasSize[] = { 10.0f, 10.0f }, v[2 * 50], color[3], mousePos[2];
int rasterSize[] = { 800, 600 };
int numOfVertices = 0, object = 0, check = 0;
float pSize = 1.0, lWidth = 1.0;
struct vertex *first = NULL;
struct vertex *bkp = NULL;
struct vertex *bkp1 = NULL;

// Menu items
enum MENU_ITEMS
{
	Item_Clear,
	Item_Point,
	Item_Line,
	Item_Triangle,
	Item_Quad,
	Item_Polygon,
	Item_Red,
	Item_Blue,
	Item_Green,
	Item_Black,
	Item_Small,
	Item_Medium,
	Item_Large,
	Item_Quit,
};

// Resizes the canvas window
void ReSize(int w, int h)
{
	rasterSize[0] = w;
	rasterSize[1] = h;
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(0.0, canvasSize[0], 0.0, canvasSize[1]);
	glViewport(0, 0, rasterSize[0], rasterSize[1]);
	glutPostRedisplay();
}

void DrawPoints()
{
	while (bkp1 != NULL && bkp1->obj == 1)
	{
		glPointSize(bkp1->pSz);
		glLineWidth(bkp1->lWth);
		glBegin(GL_POINTS);
		glColor4f(bkp1->clr[0], bkp1->clr[1], bkp1->clr[2], 1.0f);
		glVertex2fv(bkp1->coordinate);
		bkp1 = bkp1->next;
		glEnd();
	}
	bkp = bkp1;
}

void DrawLines()
{
	glPointSize(bkp1->pSz);
	glLineWidth(bkp1->lWth);
	glBegin(GL_LINE_STRIP);
	while (bkp1 != NULL && bkp1->obj == 2)
	{
		glColor3f(bkp1->clr[0], bkp1->clr[1], bkp1->clr[2]);
		glVertex2fv(bkp1->coordinate);
		if (bkp1->next != NULL && bkp1->next->chk == 1)
		{
			bkp1 = bkp1->next;
			bkp = bkp1;
			glEnd();
			return;
		}
		bkp1 = bkp1->next;
	}
	if (check == 0)
		glVertex2fv(mousePos);
	bkp = bkp1;
	glEnd();
}

void DrawTriangles()
{
	glPointSize(pSize);
	glLineWidth(lWidth);
	int count = 0;
	bkp = bkp1;
	while (bkp != NULL && bkp->obj == 3)
	{
		count++;
		bkp = bkp->next;
	}

	int numOfTriangles = count / 3, cnt = 0;
	if (numOfTriangles > 0)
	{
		glBegin(GL_TRIANGLES);
		bkp = bkp1;
		while (bkp != NULL && cnt < numOfTriangles * 3)
		{
			glColor3f(bkp->clr[0], bkp->clr[1], bkp->clr[2]);
			glVertex2fv(bkp->coordinate);
			bkp = bkp->next;
			cnt++;
		}
		glEnd();

		if (bkp != NULL && bkp->obj != 3)
		{
			bkp1 = bkp;
			return;
		}

		glBegin(GL_LINE_STRIP);
		while (bkp != NULL && cnt >= numOfTriangles * 3)
		{
			glColor3f(bkp->clr[0], bkp->clr[1], bkp->clr[2]);
			glVertex2fv(bkp->coordinate);
			bkp = bkp->next;
		}
		glVertex2fv(mousePos);
		glEnd();
	}
	else
	{
		glBegin(GL_LINE_STRIP);
		bkp = bkp1;
		while (bkp != NULL)
		{
			glColor3f(bkp->clr[0], bkp->clr[1], bkp->clr[2]);
			glVertex2fv(bkp->coordinate);
			bkp = bkp->next;
		}
		glVertex2fv(mousePos);
		glEnd();
	}
}

void DrawQuads()
{
	glPointSize(pSize);
	glLineWidth(lWidth);
	int count = 0;
	bkp = bkp1;
	while (bkp != NULL && bkp->obj == 4)
	{
		count++;
		bkp = bkp->next;
	}

	int numOfQuads = count / 4, cnt = 0;
	if (numOfQuads > 0)
	{
		glBegin(GL_QUADS);
		bkp = bkp1;
		while (bkp != NULL && cnt < numOfQuads * 4)
		{
			glColor3f(bkp->clr[0], bkp->clr[1], bkp->clr[2]);
			glVertex2fv(bkp->coordinate);
			bkp = bkp->next;
			cnt++;
		}
		glEnd();

		if (bkp != NULL && bkp->obj != 4)
		{
			bkp1 = bkp;
			return;
		}

		glBegin(GL_LINE_STRIP);
		while (bkp != NULL && cnt >= numOfQuads * 4)
		{
			glColor3f(bkp->clr[0], bkp->clr[1], bkp->clr[2]);
			glVertex2fv(bkp->coordinate);
			bkp = bkp->next;
		}
		glVertex2fv(mousePos);
		glEnd();
	}
	else
	{
		glBegin(GL_LINE_STRIP);
		bkp = bkp1;
		while (bkp != NULL)
		{
			glColor3f(bkp->clr[0], bkp->clr[1], bkp->clr[2]);
			glVertex2fv(bkp->coordinate);
			bkp = bkp->next;
		}
		glVertex2fv(mousePos);
		glEnd();
	}
}

void DrawPolys()
{
	glPointSize(pSize);
	glLineWidth(lWidth);
	glBegin(GL_TRIANGLE_STRIP);
	while (bkp1 != NULL && bkp1->obj == 5)
	{
		glColor3f(bkp1->clr[0], bkp1->clr[1], bkp1->clr[2]);
		glVertex2fv(bkp1->coordinate);
		if (bkp1->next != NULL && bkp1->next->chk == 1)
		{
			bkp1 = bkp1->next;
			bkp = bkp1;
			glEnd();
			return;
		}
		bkp1 = bkp1->next;
	}
	if (check == 0)
		glVertex2fv(mousePos);
	bkp = bkp1;
	glEnd();
}

void DrawCanvas()
{
	if (first != NULL)
	{
		bkp = first;
		bkp1 = first;

		while (bkp != NULL)
		{
			if (bkp1 != NULL && bkp1->obj == 1)
				DrawPoints();
			else if (bkp1 != NULL && bkp1->obj == 2)
				DrawLines();
			else if (bkp1 != NULL && bkp1->obj == 3)
				DrawTriangles();
			else if (bkp1 != NULL && bkp1->obj == 4)
				DrawQuads();
			else if (bkp1 != NULL && bkp1->obj == 5)
				DrawPolys();
			else
				bkp = bkp->next;
		}
	}
}

void init(void)
{
	for (int i = 0; i<100; i++)
		v[i] = 0.0f;

	// Sets initial color
	color[0] = 1.0f;
	color[1] = 0.0f;
	color[2] = 0.0f;

	// Initializes menu item
	MENU_ITEMS mItm = Item_Clear;
}

// called when the GL context need to be rendered
void display(void)
{
	// clear the screen to white, which is the background color
	glClearColor(1.0, 1.0, 1.0, 0.0);

	// clear the buffer stored for drawing
	glClear(GL_COLOR_BUFFER_BIT);

	// specify the color for new drawing
	//glColor3f(color[0], color[1], color[2]);

	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();

	DrawCanvas();

	glutSwapBuffers();
}

void OnMouseClick(int button, int state, int x, int y)
{
	if (button == GLUT_LEFT_BUTTON && state == GLUT_DOWN && object != 0)
	{
		if (object == 1)
			if (numOfVertices >= 1)
				numOfVertices = 0;

		if (object == 3)
			if (numOfVertices >= 3)
				numOfVertices = 0;

		if (object == 4)
			if (numOfVertices >= 4)
				numOfVertices = 0;

		mousePos[0] = (float)x / rasterSize[0] * canvasSize[0];
		mousePos[1] = (float)(rasterSize[1] - y) / rasterSize[1] * canvasSize[1];
		v[numOfVertices * 2 + 0] = mousePos[0];
		v[numOfVertices * 2 + 1] = mousePos[1];

		struct vertex *temp1;
		struct vertex *temp2;
		temp1 = (struct vertex *)malloc(sizeof(struct vertex));
		temp1->coordinate[0] = mousePos[0];
		temp1->coordinate[1] = mousePos[1];
		temp1->obj = object;
		temp1->clr[0] = color[0];
		temp1->clr[1] = color[1];
		temp1->clr[2] = color[2];
		temp1->pSz = pSize;
		temp1->lWth = lWidth;

		if (check == 1 && (object == 2 || object == 5))
		{
			temp1->chk = 1;
			check = 0;
		}
		else
			temp1->chk = 0;
		temp2 = first;
		if (first == NULL)
		{
			first = temp1;
			first->next = NULL;
		}
		else
		{
			while (temp2->next != NULL)
				temp2 = temp2->next;

			temp1->next = NULL;
			temp2->next = temp1;
		}

		numOfVertices++;

		glutPostRedisplay();
	}
}

void OnMouseMove(int x, int y)
{
	mousePos[0] = (float)x / rasterSize[0] * canvasSize[0];
	mousePos[1] = (float)(rasterSize[1] - y) / rasterSize[1] * canvasSize[1];
	glutPostRedisplay();
}

void OnKeyDown(unsigned char key, int x, int y)
{
	switch (key)
	{
	case 27:
		exit(0);
		break;

	case 13:
		check = 1;
		display();
		break;
	}
}

void MenuPopUp(int item)
{
	switch (item)
	{
	case Item_Clear:
		first = NULL;
		bkp = NULL;
		bkp1 = NULL;
		object = 0;
		display();
		break;
	case Item_Point:
		object = 1;
		break;
	case Item_Line:
		//check = 0;
		object = 2;
		numOfVertices = 0;
		break;
	case Item_Triangle:
		object = 3;
		break;
	case Item_Quad:
		object = 4;
		break;
	case Item_Polygon:
		//check = 0;
		object = 5;
		break;
	case Item_Red:
		color[0] = 1.0f;
		color[1] = 0.0f;
		color[2] = 0.0f;
		break;
	case Item_Blue:
		color[0] = 0.0f;
		color[1] = 0.0f;
		color[2] = 1.0f;
		break;
	case Item_Green:
		color[0] = 0.0f;
		color[1] = 1.0f;
		color[2] = 0.0f;
		break;
	case Item_Black:
		color[0] = 0.0f;
		color[1] = 0.0f;
		color[2] = 0.0f;
		break;
	case Item_Small:
		pSize = 1.0f;
		lWidth = 1.0f;
		break;
	case Item_Medium:
		pSize = 2.5f;
		lWidth = 2.5f;
		break;
	case Item_Large:
		pSize = 5.0f;
		lWidth = 5.0f;
		break;
	case Item_Quit:
		exit(0);
	default:
		break;
	}
	return;
}

void CreateMenuItems()
{
	//Submenu for colors
	int colorMenu = glutCreateMenu(MenuPopUp);
	glutAddMenuEntry("Red", Item_Red);
	glutAddMenuEntry("Green", Item_Green);
	glutAddMenuEntry("Blue", Item_Blue);
	glutAddMenuEntry("Black", Item_Black);

	//Submenu for sizes
	int sizeMenu = glutCreateMenu(MenuPopUp);
	glutAddMenuEntry("Small", Item_Small);
	glutAddMenuEntry("Medium", Item_Medium);
	glutAddMenuEntry("Larger", Item_Large);

	//Submenu for objects
	int objectMenu = glutCreateMenu(MenuPopUp);
	glutAddMenuEntry("Point", Item_Point);
	glutAddMenuEntry("Line", Item_Line);
	glutAddMenuEntry("Triangle", Item_Triangle);
	glutAddMenuEntry("Quad", Item_Quad);
	glutAddMenuEntry("Polygon", Item_Polygon);

	//Mainmenu for the canvas window
	glutCreateMenu(MenuPopUp);
	glutAddMenuEntry("Clear", Item_Clear);
	glutAddSubMenu("Objects", objectMenu);
	glutAddSubMenu("Colors", colorMenu);
	glutAddSubMenu("Sizes", sizeMenu);
	glutAddMenuEntry("Quit", Item_Quit);

	glutAttachMenu(GLUT_RIGHT_BUTTON);
}

int main(int argc, char *argv[])
{
	init();

	// Initializes the GLUT library
	glutInit(&argc, argv);

	glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGBA);

	// Sets the initial dimensions of the canvas window
	glutInitWindowSize(rasterSize[0], rasterSize[1]);

	// Creates the canvas window with the specified dimensions
	glutCreateWindow("Interactive 2D Graphics Window");

	// Registers user-defined functions to operate on the canvas window
	glutReshapeFunc(ReSize);
	glutDisplayFunc(display);

	// Registers user-defined function: OnMouseClick to handle mouse click events in  the canvas window
	glutMouseFunc(OnMouseClick);
	glutPassiveMotionFunc(OnMouseMove);
	glutKeyboardFunc(OnKeyDown);

	/* -----------Creates menu items-------------- */
	CreateMenuItems();

	glutMainLoop();

	return 0;
}