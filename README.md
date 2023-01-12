# DotNetIM
- # 介绍 
- 该项目使用.net 6实现,基于微服务架构的分布式im(即时通讯)
- 项目整体基于.net6 web api 实现

| 功能    | 技术选型  |
| :-----  | ------   | 
| 微服务网关  | ocelot | 
| 注册中心  | nacos | 
| 服务调用  | 增强HttpClient|
| 缓存  | redis |
| 数据库  | mysql |
| 网络框架  | dotnetty |
| 通信协议  | protobuf |

# 开发计划
- [x] 私聊
- [x] 联系人操作
- [x] 通信协议(基于protobuf)实现
- [x] 心跳
- [x] 鉴权
- [x] 集群支持
- [x] [Sdk开发包](https://github.com/adminoryuan/dotnet-im/blob/master/SDKREADME.md)
- [ ] 广播消息
- [ ] 离线消息
- [ ] 群聊


 # 项目介绍
- # im-forward-service 
- 对外提供推送消息
- 消息持久化
- 添加用户与主机路由
- # im-system-service 服务
- 登录、注册
- 提供联系人、群组相关接口
- # im-dotnetty-service
- 使用dotnetty 实现tcp长连接
- 提供消息推送接口
- 心跳监测
- # geteway-service 服务
- 统一接口访问
- 鉴权
- 限流
