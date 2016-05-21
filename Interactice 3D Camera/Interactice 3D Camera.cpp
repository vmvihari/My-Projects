/*
Interactice 3D Camera.cpp : Defines the entry point for the console application.
Author: Monish Vihari Vappangi
Description: Simulates two modes of camera: 
--> Mode - 1: First person mode
	--> Move forward, backward, left and right
	--> Rotate horizontally and vertically
--> Mode - 1: Focus mode
	--> Rotate eye about up vector
	--> Panning
	--> Zooming
*/

#include "stdafx.h"
#include <GL/glut.h>
#include <iostream>
#include <math.h>
#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>
using namespace std;

glm::vec3 CameraEye, CameraLookAt, CameraUp, CameraTemp, CameraU, CameraV;
GLfloat RotationSpeed = 0.05f, MovementSpeed = 2.0f;
int g_winWidth = 1024, g_winHeight = 512, prevX = 0, prevY = 0, mode = 1;
char mouse = 'L';
float length = 17.32, yaw = -45.0, pitch = 30.0;

// Resizes the canvas window
void ReSize(int w, int h)
{
	g_winWidth = w;
	g_winHeight = h;
	glViewport(0, 0, w, h);
}

void initialGL()
{
	glEnable(GL_DEPTH_TEST);
	glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
}

void initialization()
{
	CameraEye = glm::vec3(10.0f, 10.0f, -10.0f);
	CameraLookAt[0] = CameraEye[0] - length * cos(glm::radians(yaw)) * cos(glm::radians(pitch));
	CameraLookAt[1] = CameraEye[1] - length * sin(glm::radians(pitch));
	CameraLookAt[2] = CameraEye[2] - length * sin(glm::radians(yaw)) * cos(glm::radians(pitch));
	CameraUp = glm::vec3(0.0f, 1.0f, 0.0f);
}

void drawCS()
{
	glMatrixMode(GL_MODELVIEW);
	glPushMatrix();
	glScalef(10.0f, 10.0f, 10.0f);
	glLineWidth(2.5f);
	glBegin(GL_LINES);

	//axis x
	glColor3f(1.0f, 0.0f, 0.0f);
	glVertex3f(0.0f, 0.0f, 0.0f);
	glVertex3f(0.3f, 0.0f, 0.0f);

	//text x
	glVertex3f(0.4f, 0.03f, 0.0f);
	glVertex3f(0.43f, -0.03f, 0.0f);
	glVertex3f(0.4f, -0.03f, 0.0f);
	glVertex3f(0.43f, 0.03f, 0.0f);

	//axis y
	glColor3f(0.0f, 1.0f, 0.0f);
	glVertex3f(0.0f, 0.0f, 0.0f);
	glVertex3f(0.0f, 0.3f, 0.0f);

	//text y
	glVertex3f(0.0f, 0.5f, 0.0f);
	glVertex3f(0.0f, 0.4f, 0.0f);
	glVertex3f(-0.05f, 0.55f, 0.0f);
	glVertex3f(0.0f, 0.5f, 0.0f);
	glVertex3f(0.05f, 0.55f, 0.0f);
	glVertex3f(0.0f, 0.5f, 0.0f);

	//axis z
	glColor3f(0.0f, 0.0f, 1.0f);
	glVertex3f(0.0f, 0.0f, 0.0f);
	glVertex3f(0.0f, 0.0f, 0.3f);

	//text z
	glVertex3f(-0.025f, 0.025f, 0.4f);
	glVertex3f(0.025f, 0.025f, 0.4f);
	glVertex3f(0.025f, 0.025f, 0.4f);
	glVertex3f(-0.025f, -0.025f, 0.4f);
	glVertex3f(-0.025f, -0.025f, 0.4f);
	glVertex3f(0.025f, -0.025f, 0.4f);

	glEnd();
	glLineWidth(1.0f);

	glPopMatrix();
}

void drawGrid()
{
	int size = 25;

	if (size % 2 != 0) 
		++size;

	glMatrixMode(GL_MODELVIEW);
	glPushMatrix();
	glBegin(GL_LINES);
	for (int i = 0; i < size + 1; i++)
	{
		if ((float)i == size / 2.0f)
			glColor3f(0.0f, 0.0f, 0.0f);
		else
			glColor3f(0.8f, 0.8f, 0.8f);

		glVertex3f(-size / 2.0f, 0.0f, -size / 2.0f + i);
		glVertex3f(size / 2.0f, 0.0f, -size / 2.0f + i);
		glVertex3f(-size / 2.0f + i, 0.0f, -size / 2.0f);
		glVertex3f(-size / 2.0f + i, 0.0f, size / 2.0f);
	}
	glEnd();
	glPopMatrix();
}

// called when the GL context need to be rendered
void display(void)
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	gluLookAt(CameraEye[0], CameraEye[1], CameraEye[2], CameraLookAt[0], CameraLookAt[1], CameraLookAt[2], CameraUp[0], CameraUp[1], CameraUp[2]);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(45, g_winWidth / g_winHeight, 0.1, 100);
	drawGrid();
	drawCS();
	glutSwapBuffers();
}

void OnMouseClick(int button, int state, int x, int y)
{
	prevX = x;
	prevY = y;

	if (button == GLUT_LEFT_BUTTON && state == GLUT_DOWN)
	{
		if (mode == 2)
			mouse = 'L';
	}
	else if (button == GLUT_RIGHT_BUTTON && state == GLUT_DOWN)
	{
		if (mode == 2)
			mouse = 'R';
	}
	else if (button == GLUT_MIDDLE_BUTTON && state == GLUT_DOWN)
	{
		if (mode == 2)
			mouse = 'M';
	}
	glutPostRedisplay();
}

void OnMouseMove(int x, int y)
{
	yaw += (x - prevX) * RotationSpeed;
	pitch += (y - prevY) * RotationSpeed;

	if (mode == 1)
	{
		if (pitch > 89.0f)
			pitch = 89.0f;
		if (pitch < -89.0f)
			pitch = -89.0f;

		CameraLookAt[0] = CameraEye[0] - length * cos(glm::radians(yaw)) * cos(glm::radians(pitch));
		CameraLookAt[1] = CameraEye[1] - length * sin(glm::radians(pitch));
		CameraLookAt[2] = CameraEye[2] - length * sin(glm::radians(yaw)) * cos(glm::radians(pitch));
	}
	else if (mode == 2)
	{
		if (mouse == 'L')
		{
			CameraEye[0] = CameraLookAt[0] + length * cos(glm::radians(yaw)) * cos(glm::radians(pitch));
			CameraEye[1] = CameraLookAt[1] + length * sin(glm::radians(pitch));
			CameraEye[2] = CameraLookAt[2] + length * sin(glm::radians(yaw)) * cos(glm::radians(pitch));
		}
		else if (mouse == 'R')
		{
			if (x > prevX)
			{
				CameraEye += 0.05f * glm::vec3(CameraLookAt - CameraEye);
				length = glm::distance(CameraLookAt, CameraTemp);
			}
			else if (x < prevX)
			{
				CameraEye -= 0.05f * glm::vec3(CameraLookAt - CameraEye);
				length = glm::distance(CameraLookAt, CameraTemp);
			}
		}
		else if (mouse == 'M')
		{
			GLfloat rx = (x - prevX) * 0.05;
			GLfloat ry = (y - prevY) * 0.05;
			CameraU = glm::cross(CameraUp, CameraLookAt - CameraEye);
			CameraV = glm::cross(CameraLookAt - CameraEye, CameraU);
			CameraEye += glm::normalize(CameraU) * rx;
			CameraEye += glm::normalize(CameraV) * ry;
			CameraLookAt += glm::normalize(CameraU) * rx;
			CameraLookAt += glm::normalize(CameraV) * ry;
		}
	}
	prevX = x;
	prevY = y;
	glutPostRedisplay();
}

void OnKeyDown(unsigned char key, int x, int y)
{
	switch (key)
	{
	case 27:
		exit(0);
		break;

	case 67: //C key
	case 99: //c key
		if (mode == 1)
			mode = 2;
		else if (mode == 2)
			mode = 1;
		break;

	case 65: //A key
	case 97: //a key
		if (mode == 1)
			CameraEye -= glm::normalize(glm::cross(CameraLookAt - CameraEye, CameraUp)) * MovementSpeed;
		break;

	case 87: //W key
	case 119: //w key
		if (mode == 1)
			CameraEye += MovementSpeed * glm::normalize(CameraLookAt - CameraEye);
		break;

	case 68: //D key
	case 100: //d key
		if (mode == 1)
			CameraEye += glm::normalize(glm::cross(CameraLookAt - CameraEye, CameraUp)) * MovementSpeed;
		break;

	case 83: //S key
	case 115: //s key
		if (mode == 1)
			CameraEye -= MovementSpeed * glm::normalize(CameraLookAt - CameraEye);
		break;
	}

	CameraLookAt[0] = CameraEye[0] - length * cos(glm::radians(yaw)) * cos(glm::radians(pitch));
	CameraLookAt[1] = CameraEye[1] - length * sin(glm::radians(pitch));
	CameraLookAt[2] = CameraEye[2] - length * sin(glm::radians(yaw)) * cos(glm::radians(pitch));
	glutPostRedisplay();
}

int main(int argc, char *argv[])
{
	// Initializes the GLUT library
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DEPTH | GLUT_DOUBLE | GLUT_RGB);
	// Sets the initial dimensions of the canvas window
	glutInitWindowSize(g_winWidth, g_winHeight);
	glutInitWindowPosition(0, 0);
	// Creates the canvas window with the specified dimensions
	glutCreateWindow("Interactive 3D Camera");
	initialGL();
	// Registers user-defined functions to operate on the canvas window
	glutReshapeFunc(ReSize);
	glutDisplayFunc(display);
	// Registers user-defined function: OnMouseClick to handle mouse click events in  the canvas window
	glutMouseFunc(OnMouseClick);
	glutMotionFunc(OnMouseMove);
	glutKeyboardFunc(OnKeyDown);
	initialization();
	glutMainLoop();
	return EXIT_SUCCESS;
}