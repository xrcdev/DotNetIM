# dotnet-im
- # 使用.net 6实现,基于微服务架构的分布式im
- 技术栈 dotnetty mysql  redis nacos ocelot
- 项目架构图
# 开发计划
- [x] 私聊
- [x] 添加联系人
- [x] 心跳
- [x] 集群支持
- [ ] sdk
- [ ] 离线消息
- [ ] 群聊

 # 本项目一共分为四个微服务
- # im-forward-service 
- 对外提供推送消息
- 消息持久化
- 添加用户与主机路由
- # im-system-service 服务
- 登录、注册
- 提供联系人、群组相关接口
- # im-dotnetty-service
- 使用dotnetty 实现tcp长连接
- # geteway-service 服务
- 统一接口访问
- 鉴权
