# ABB 控制平台使用方法

本文档详细说明如何在 Visual Studio 和 RobotStudio 环境下配置 ABB 控制平台。

---

## 1. 确保所连接的实际机器人系统或者虚拟机器人系统具有616-1 PC Interface 选项和 689-1 Externally Guided Motion(EGM)选项



---

## 2. 打开项目

在 **Visual Studio** 中打开以下解决方案文件：

- `WinFormsControlLibrary2.sln`

---

## 3. 下载 .NET 包

在 **.NET 包管理器** 中下载并安装以下依赖包：

- **Google.Protobuf**
- **Google.ProtocolBuffers**
- **HIC.System.Windows.Forms.DataVisualization**
- **HslCommunication**
- **MathNet.Numerics**

---

## 4. 引用必要文件

将 **FUJIAN** 文件夹中的所有文件添加至项目程序集作为引用。

---

## 5. 添加 Rapid 代码到 RobotStudio

在 **RobotStudio** 中引入 Rapid 程序代码，具体操作如下：

- 打开或添加 `backup-Robotstudio` 文件夹中的 Rapid 程序代码。

---

> **提示：** 请确保所有文件路径、包名称以及版本号均正确无误，以保证平台的正常运行。












