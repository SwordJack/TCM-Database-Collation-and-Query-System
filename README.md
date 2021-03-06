# 中医药数据库整理与查询系统</br>TCM Database Collation and Query System

    原名：TCM_Assembly（中医药数据库整理）  
    An ongoing project to collate Traditional Chinese Medicine databases.  
    一项正在进行中的中医药数据库整理项目。

## 项目介绍

    本项目是华东理工大学药学院大学生暑期社会实践团下中医药数据库整理项目的进展代码库。
    项目负责人：Shen W. Juan；
    项目成员：Zhong Y. Jie、Mao Z. Yu、Xu J. Hao、Zhang W. Xian；
    数据库设计、程序设计、代码库管理：Zhong Y. Jie。

## 项目概述

    1、客户端以C# .NET设计Windows窗体应用程序，租赁腾讯云服务器以SQL Server提供数据库服务；  
    2、依据《GB/T31773-2015中药方剂编码规则及编码》和《GB/T31774-2015中药编码规则及编码》设计数据结构，并录入药物信息，实现药物信息、药物来源、药用部位、药材切制规格和炮炙方法的查询；

## 代码库情况

    1、主要的程序代码可通过“中医药数据库整理与查询系统.sln”在Visual Studio 2019中进行查看（源代码中涉及域名或IP地址等的信息已经被清理）；
    2、数据库的架构与数据在“SQL_Source_Code”文件夹下，以脚本形式保存，可在SQL Server 2017中（作者所使用之版本），建立好名为“TraditionalChineseMedicine”的数据库后运行此脚本，以直接装载数据；
    3、数据库建立所依据的两份标准文件在“References”文件夹下，作者及合作开发的各方发现并纠正了标准文件中的部分错误（见文件“WorkNote_20190825_药物代码纠正.docx”）。

## 项目进展

### v1.0.2.4.1

    时间：2019.09.03
    修复了药物信息查询界面可能不返回第一个结果集的问题。

### v1.0.2.4

    时间：2019.08.25
    修复了不返回结果集时程序消息窗口的显示问题。

## v1.0.2.3

    时间：2019.08.25
    1、修复了无法去除录入方剂别名的表格中的无意义空格的问题；
    2、修复了方剂别名表格中的“说明”列无法去除换行的问题。

### v0.0.2.3

    时间：2019.08.24
    1、建成了可供公众进行数据库访问的“中医药数据库查询”客户端；
    2、建成并部署了网站。

### v0.0.2.2

    时间：2019.08.23
    1、修复了方剂录入时“方剂名称”文本框的处理文本无效的问题；
    2、修复了“功效”、“主治”文本框为空时，处理文本报错的问题；
    3、添加了对“说明”文本框进行文本处理的功能；
    4、添加了方剂录入时对“组成”文本框的检查；
    5、取消了“录入操作不可用”警示后按钮状态的改变；
    6、添加了对“方剂别名”表格中的文本的简单处理；
    7、添加了方剂录入时对“处理文本”次数的简单检查；
    8、修改了方剂录入标签页的控件的TabIndex。

### v0.0.2.1

    时间：2019.08.23
    1、增加了方剂信息的录入、删除、查询功能；
    2、正在进行网站的建设工作和部署准备。

### v0.0.1.5

    时间：2019.08.07
    1、修复了“药物信息”表的“说明”列会录入成“品名”的错误；
    2、改进了录入操作成功后，在“消息窗口”文本框显示的录入信息的文本格式；
    3、改进了登录界面的label提示信息的显示方式和业务逻辑。

### v0.0.1.4

    时间：2019.08.04
    1、此次修改主要针对界面交互性进行优化。
    2、录入操作的结果反馈方式修改为：录入操作成功后，会在“消息窗口”文本框显示录入的信息，并清空标签页内文本框中的文本。

### v0.0.1.3

    时间：2019.08.03  
    1、修改了数据库的“药物别名”表数据结构，同时调整了客户端向数据库存储过程的实参传递；  
    2、为避免忘记录入药物别名的情况的发生，在“录入” 标签页，点击“录入”按钮后，若“药物别名”文本框为空，则会弹出对话框，询问“你确定这味药物没有别名吗？”，点击“确认”后，程序才会继续录入流程。

### v0.0.1.1

    时间：2019.08.02  
    1、项目的在线工作部分启动，可以开始进行药物信息录入；  
    2、药物（根据药物名称）全信息查询和药物来源、药用部位、药材切制规格及炮炙方法的查询功能已实现（药物来源表尚未录入数据）。  

## 后续建设计划

    本系统将在2020年第1季度进行二期建设。
    二期建设目标为建立网页端的中医药数据查询通道，并向数据库中的药物信息条目加入图片（必做）以及一些方剂歌谣、药物或方剂相关的民间奇闻异事等趣味内容（视情况而定），改造后原有客户端将不再可用。
    建设过程：
    （1）不对数据结构进行整体上的重构；
    （2）除添加图片外，对已有数据的改动原则上不超过2%；
    （3）探索建立以ASP.NET Core为后端的Web应用程序提供数据服务；
    （4）将主要的工作重心放在优化检索逻辑、美化用户界面、提升查询体验上；

## 版权信息

    1、本作品业已以“中医药数据库整理与查询系统”的名称在中国版权保护中心登记计算机软件著作权，但作者依旧以GNU General Public License v3协议将本作品开源共享，望各位遵守开源协议，维护良好的开源社区环境，使创作成果更好地服务广大工农群众；
    2、本作品的合作开发协议书中已写明，本作品不可被合作开发的各方及任何第三方用于任何商业目的。对不遵守开源协议的使用者，作者保留以著作权人的身份追究其包括但不限于侵权等责任的一切权利；

![“中医药数据库整理与查询”软件著作权登记证书](./References/“中医药数据库整理与查询系统”证书_正本_覆盖部分姓名.jpg "软件著作权登记证书_正本")

    CopyLeft 2019 - Forever, Zhong Y. Jie. Partial Rights Reserved, Licensed Under GNU GPL v3.
    本应用及其相关内容不用于且不可以任何理由用于任何商业目的；作者对其使用不收取任何费用，对其造成之后果不担负任何责任。
