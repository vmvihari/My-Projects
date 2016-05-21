/*
HierarchicalTransformations.cpp : Defines the entry point for the console application.
Author: Monish Vihari Vappangi
Description: Draws a robot with 16 different parts where each part can be selected and rotated about its axis.
*/

#include "stdafx.h"
#include <GL/glut.h>
#include <iostream>
using namespace std;

float canvasSize[] = { 30.0f, 30.0f }, v[2 * 50], color[3], mousePos[2];
int rasterSize[] = { 800, 600 };
int RoboParts = 10;
float PartAngle[17];
float pSize = 1.0, lWidth = 1.0;

void init(void)
{
	// Sets initial color
	color[0] = 1.0f;
	color[1] = 0.0f;
	color[2] = 0.0f;

	for (int i = 0; i < 17; i++)
		PartAngle[i] = 0;
}

void initColor(int part)
{
	if (RoboParts == part)
	{
		color[0] = 0.0;
		color[1] = 0.0;
		color[2] = 0.0;
	}
	else
	{
		for (int j = 0; j < 3; j++)
		{
			color[j] = (float)rand() / (RAND_MAX + 1);
		}

		if (color[0] == 0.0 && color[1] == 0.0 && color[2] == 0)
			color[1] = 1.0;
	}
}

// Resizes the canvas window
void ReSize(int w, int h)
{
	rasterSize[0] = w;
	rasterSize[1] = h;
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(-canvasSize[0] / 2, canvasSize[0] / 2, -canvasSize[1] / 2, canvasSize[1] / 2);
	glViewport(0, 0, rasterSize[0], rasterSize[1]);
	glutPostRedisplay();
}

// Draws a rectangle with specified length and breadth
void drawQuad(float length, float breadth, float* color, char direct)
{
	glColor3fv(color);
	glLineWidth(3.0f);
	float left = 0.0, right = 0.0, top = 0.0, bottom = 0.0;
	if (direct == 'U')
	{
		left = length / 2;
		right = right - left;
		top = breadth;
	}
	else if (direct == 'L')
	{
		left = left - length;
		top = breadth / 2;
		bottom = bottom - top;
	}
	else if (direct == 'R')
	{
		right = length;
		top = breadth / 2;
		bottom = bottom - top;
	}
	else if (direct == 'D')
	{
		right = length / 2;
		left = left - right;
		bottom = bottom - breadth;
	}
	else if (direct == 'P')
	{
		right = length / 4;
		left = left - (length - right);
		bottom = bottom - breadth;
	}
	else if (direct == 'Q')
	{
		left = left - (length / 4);
		right = length - (length / 4);
		bottom = bottom - breadth;
	}
	glBegin(GL_QUADS);
	glVertex2f(left, bottom);
	glVertex2f(left, top);
	glVertex2f(right, top);
	glVertex2f(right, bottom);
	glEnd();
	glLineWidth(1.0f);
	printf("left: %f\tright: %f\ttop: %f\tbottom: %f\n", left, right, top, bottom);
}

// Draws robot parts
void DrawCanvas()
{
	//Lower Body
	glRotatef(PartAngle[10], 0.0, 0.0, 1.0);
	glPushMatrix();
	glPushMatrix();
	glPushMatrix();
	initColor(10);
	drawQuad(4.0, 3.0, color, 'U');

	//Upper Body
	glTranslatef(0.0, 3.0, 0.0);
	glRotatef(PartAngle[3], 0.0, 0.0, 1.0);
	glPushMatrix();
	glPushMatrix();
	glPushMatrix();
	initColor(3);
	drawQuad(6.0, 3.0, color, 'U');

	//Right Arm
	glTranslatef(0.0, 1.5, 0.0);
	glTranslatef(-3.0, 0, 0);
	glRotatef(PartAngle[4], 0.0, 0.0, 1.0);
	glPushMatrix();
	initColor(4);
	drawQuad(2.0, 1.0, color, 'L');

	//Right Forarm
	glTranslatef(-2.0, 0, 0);
	glRotatef(PartAngle[5], 0.0, 0.0, 1.0);
	glPushMatrix();
	initColor(5);
	drawQuad(2.0, 1.0, color, 'L');

	//Right Hand
	glTranslatef(-2.0, 0, 0);
	glRotatef(PartAngle[6], 0.0, 0.0, 1.0);
	initColor(6);
	drawQuad(2.0, 2.0, color, 'L');

	glPopMatrix();
	glPopMatrix();
	glPopMatrix();

	//Left Arm
	glTranslatef(0.0, 1.5, 0.0);
	glTranslatef(3.0, 0, 0);
	glRotatef(PartAngle[7], 0.0, 0.0, 1.0);
	glPushMatrix();
	initColor(7);
	drawQuad(2.0, 1.0, color, 'R');

	//Left Forarm
	glTranslatef(2.0, 0, 0);
	glRotatef(PartAngle[8], 0.0, 0.0, 1.0);
	glPushMatrix();
	initColor(8);
	drawQuad(2.0, 1.0, color, 'R');

	//Left Hand
	glTranslatef(2.0, 0, 0);
	glRotatef(PartAngle[9], 0.0, 0.0, 1.0);
	initColor(9);
	drawQuad(2.0, 2.0, color, 'R');

	glPopMatrix();
	glPopMatrix();
	glPopMatrix();

	//Neck
	glTranslatef(0, 3.0, 0);
	glRotatef(PartAngle[2], 0.0, 0.0, 1.0);
	glPushMatrix();
	initColor(2);
	drawQuad(1.5, 2.0, color, 'U');

	//Head
	glTranslatef(0, 2.0, 0);
	glRotatef(PartAngle[1], 0.0, 0.0, 1.0);
	initColor(1);
	drawQuad(3.0, 3.0, color, 'U');

	glPopMatrix();
	glPopMatrix();
	glPopMatrix();

	//Right Tigh
	glTranslatef(-1.5, 0, 0);
	glRotatef(PartAngle[11], 0.0, 0.0, 1.0);
	glPushMatrix();
	initColor(11);
	drawQuad(1.0, 3.0, color, 'D');

	//Right Leg
	glTranslatef(0, -3.0, 0);
	glRotatef(PartAngle[13], 0.0, 0.0, 1.0);
	glPushMatrix();
	initColor(13);
	drawQuad(1.0, 3.0, color, 'D');

	//Right Foot
	glTranslatef(0, -3.0, 0);
	glRotatef(PartAngle[15], 0.0, 0.0, 1.0);
	initColor(15);
	drawQuad(2.0, 1.0, color, 'P');

	glPopMatrix();
	glPopMatrix();
	glPopMatrix();

	//Left Tigh
	glTranslatef(1.5, 0, 0);
	glRotatef(PartAngle[12], 0.0, 0.0, 1.0);
	glPushMatrix();
	initColor(12);
	drawQuad(1.0, 3.0, color, 'D');

	//Left Leg
	glTranslatef(0, -3.0, 0);
	glRotatef(PartAngle[14], 0.0, 0.0, 1.0);
	glPushMatrix();
	initColor(14);
	drawQuad(1.0, 3.0, color, 'D');

	//Left Foot
	glTranslatef(0, -3.0, 0);
	glRotatef(PartAngle[16], 0.0, 0.0, 1.0);
	initColor(16);
	drawQuad(2.0, 1.0, color, 'Q');

	glPopMatrix();
	glPopMatrix();
	glPopMatrix();
}

void renderBitmapString(float x, float y, void *font, const char *string)
{
	const char *c;
	glRasterPos2f(x, y);
	for (c = string; *c != '\0'; c++) {
		glutBitmapCharacter(font, *c);
	}
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

	glColor3f(0.0f, 0.0f, 0.4f);
	renderBitmapString(-13, 13, GLUT_BITMAP_HELVETICA_18, "Instructions to control the Bot:");
	renderBitmapString(-3, 13, GLUT_BITMAP_HELVETICA_12, "Black color body part  is selected for rotation");
	renderBitmapString(-13, 11.5, GLUT_BITMAP_HELVETICA_12, "1.  'A' or 'a'  -->  Move left");
	renderBitmapString(-13, 10.5, GLUT_BITMAP_HELVETICA_12, "2.  'D' or 'd'  -->  Move right");
	renderBitmapString(-13, 9.5, GLUT_BITMAP_HELVETICA_12, "3.  'S' or 's'  -->  Move down");
	renderBitmapString(-13, 8.5, GLUT_BITMAP_HELVETICA_12, "4.  'W' or 'w'  -->  Move up");
	renderBitmapString(-13, 7.5, GLUT_BITMAP_HELVETICA_12, "5.  'K' or 'k'  -->  Rotate anti-clockwise");
	renderBitmapString(-13, 6.5, GLUT_BITMAP_HELVETICA_12, "6.  'L' or 'l'  -->  Rotate clockwise");

	// Draws robot parts
	DrawCanvas();

	glutSwapBuffers();
}

void OnKeyDown(unsigned char key, int x, int y)
{
	switch (key)
	{
	case 27: //esc key
		exit(0);
		break;

	case 65: //A key
	case 97: //a key
		if (RoboParts == 3 || RoboParts == 4 || RoboParts == 5 || RoboParts == 10)
			RoboParts++;
		else if (RoboParts == 7)
			RoboParts = 3;
		else if (RoboParts == 8 || RoboParts == 9)
			RoboParts--;
		else if (RoboParts == 12)
			RoboParts = 10;
		break;

	case 87: //W key
	case 119: //w key
		if (RoboParts == 2 || RoboParts == 3)
			RoboParts--;
		else if (RoboParts == 10)
			RoboParts = 3;
		else if (RoboParts == 13 || RoboParts == 14 || RoboParts == 15 || RoboParts == 16)
			RoboParts = RoboParts - 2;
		break;

	case 68: //D key
	case 100: //d key
		if (RoboParts == 3)
			RoboParts = 7;
		else if (RoboParts == 7 || RoboParts == 8)
			RoboParts++;
		else if (RoboParts == 4 || RoboParts == 5 || RoboParts == 6 || RoboParts == 11)
			RoboParts--;
		else if (RoboParts == 10)
			RoboParts = 12;
		break;

	case 83: //S key
	case 115: //s key
		if (RoboParts == 1 || RoboParts == 2)
			RoboParts++;
		else if (RoboParts == 3)
			RoboParts = 10;
		else if (RoboParts == 11 || RoboParts == 12 || RoboParts == 13 || RoboParts == 14)
			RoboParts = RoboParts + 2;
		break;

	case 75: //K key
	case 107: //k key
		PartAngle[RoboParts] = PartAngle[RoboParts] + 3;
		break;

	case 76: //L key
	case 108: //l key
		PartAngle[RoboParts] = PartAngle[RoboParts] - 3;
		break;
	}

	glutPostRedisplay();
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
	glutCreateWindow("Hierarchical Transformations Window");

	// Registers user-defined functions to operate on the canvas window
	glutReshapeFunc(ReSize);
	glutDisplayFunc(display);

	// Registers user-defined function: OnKeyDown to handle key click events in  the canvas window
	glutKeyboardFunc(OnKeyDown);

	glutMainLoop();

	return 0;
}