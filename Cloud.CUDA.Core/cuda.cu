// cuda.cpp : ���� DLL Ӧ�ó���ĵ���������
//

#include "pch.h"
#include "cuda_runtime.h"  
#include "device_launch_parameters.h" 
__global__ void addKernel(int* c, const int* a, const int* b);

//�������  
int _stdcall ArrayAdd(int c[], int a[], int b[], int size)
{
	int result = -1;
	int* dev_a = 0;
	int* dev_b = 0;
	int* dev_c = 0;
	cudaError_t cudaStatus;

	// ѡ���������е�GPU  
	cudaStatus = cudaSetDevice(0);
	if (cudaStatus != cudaSuccess) {
		result = 1;
		goto Error;
	}

	// ��GPU��Ϊ����dev_a��dev_b��dev_c�����ڴ�ռ�.  
	cudaStatus = cudaMalloc((void**)&dev_c, size * sizeof(int));
	if (cudaStatus != cudaSuccess) {
		result = 2;
		goto Error;
	}
	cudaStatus = cudaMalloc((void**)&dev_a, size * sizeof(int));
	if (cudaStatus != cudaSuccess) {
		result = 3;
		goto Error;
	}
	cudaStatus = cudaMalloc((void**)&dev_b, size * sizeof(int));
	if (cudaStatus != cudaSuccess) {
		result = 4;
		goto Error;
	}

	// �������ڴ渴�����ݵ�GPU�ڴ���.  
	cudaStatus = cudaMemcpy(dev_a, a, size * sizeof(int), cudaMemcpyHostToDevice);
	if (cudaStatus != cudaSuccess) {
		result = 5;
		goto Error;
	}
	cudaStatus = cudaMemcpy(dev_b, b, size * sizeof(int), cudaMemcpyHostToDevice);
	if (cudaStatus != cudaSuccess) {
		result = 6;
		goto Error;
	}

	// ����GPU�ں˺���  
	addKernel<<<1, size>>>(dev_c, dev_a, dev_b);

	// ����cudaDeviceSynchronize�ȴ�GPU�ں˺���ִ����ɲ��ҷ����������κδ�����Ϣ  
	cudaStatus = cudaDeviceSynchronize();
	if (cudaStatus != cudaSuccess) {
		result = 7;
		goto Error;
	}

	// ��GPU�ڴ��и������ݵ������ڴ���  
	cudaStatus = cudaMemcpy(c, dev_c, size * sizeof(int), cudaMemcpyDeviceToHost);
	if (cudaStatus != cudaSuccess) {
		result = 8;
		goto Error;
	}

	result = 0;

	// ����CUDA�豸�����˳�֮ǰ�������cudaDeviceReset  
	cudaStatus = cudaDeviceReset();
	if (cudaStatus != cudaSuccess) {
		return 9;
	}

Error:
	//�ͷ��豸�б�����ռ�ڴ�  
	cudaFree(dev_c);
	cudaFree(dev_a);
	cudaFree(dev_b);

	return result;

}
