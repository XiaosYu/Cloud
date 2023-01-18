// cuda.cpp : 定义 DLL 应用程序的导出函数。
//

#include "pch.h"
#include "cuda_runtime.h"  
#include "device_launch_parameters.h" 
__global__ void addKernel(int* c, const int* a, const int* b);

//向量相加  
int _stdcall ArrayAdd(int c[], int a[], int b[], int size)
{
	int result = -1;
	int* dev_a = 0;
	int* dev_b = 0;
	int* dev_c = 0;
	cudaError_t cudaStatus;

	// 选择用于运行的GPU  
	cudaStatus = cudaSetDevice(0);
	if (cudaStatus != cudaSuccess) {
		result = 1;
		goto Error;
	}

	// 在GPU中为变量dev_a、dev_b、dev_c分配内存空间.  
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

	// 从主机内存复制数据到GPU内存中.  
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

	// 启动GPU内核函数  
	addKernel<<<1, size>>>(dev_c, dev_a, dev_b);

	// 采用cudaDeviceSynchronize等待GPU内核函数执行完成并且返回遇到的任何错误信息  
	cudaStatus = cudaDeviceSynchronize();
	if (cudaStatus != cudaSuccess) {
		result = 7;
		goto Error;
	}

	// 从GPU内存中复制数据到主机内存中  
	cudaStatus = cudaMemcpy(c, dev_c, size * sizeof(int), cudaMemcpyDeviceToHost);
	if (cudaStatus != cudaSuccess) {
		result = 8;
		goto Error;
	}

	result = 0;

	// 重置CUDA设备，在退出之前必须调用cudaDeviceReset  
	cudaStatus = cudaDeviceReset();
	if (cudaStatus != cudaSuccess) {
		return 9;
	}

Error:
	//释放设备中变量所占内存  
	cudaFree(dev_c);
	cudaFree(dev_a);
	cudaFree(dev_b);

	return result;

}
