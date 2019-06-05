# ILRuntime 教程

**声明：本教程只是笔者在学习过程中的一些记录，用于备忘。仅供参考。**

本文主要介绍从零开始构建一个 ILRuntime 热更新工程，但是不会涉及具体的热更新流程。只做一些关键步骤的说明，记录踩过的坑。

## 前期准备
### 环境准备
- 本文所使用的工具版本：Unity 2018.3.11f1；VS 2017。
- ILRuntime 官网教程：https://ourpalm.github.io/ILRuntime/public/v1/guide/tutorial.html

### 资源准备
[下载](https://github.com/Ourpalm/ILRuntime/releases)最新版 ILRuntime 源码和调试工具，如下图：

![](./Images/01_github.png)

## 构建 Unity 项目
新建一个 Unity 项目 Client，项目文件夹放到 ILRuntimeDemo 文件夹下。然后将下载的 ILRuntime 原代码压缩包解压，并将下图中的三个文件夹拷贝到 Unity 项目的 Assets 文件夹下，同时将这些目录里面的 bin、obj、Properties 子目录和 .csproj 文件都删掉。在Assets目录里建立一个名为 csc.rsp 的文本文件，在 csc.rsp 文件中加入 -unsafe。Unity 项目目录结构如下图：
![](./Images/02_unity_project.png)