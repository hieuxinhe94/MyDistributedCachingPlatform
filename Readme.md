

 - Theo cách hiểu của tôi. Trong caching có 3 tùy chọn (**In-process
   cache, In-memory cache, Distributed cache**).
 - Trong bài tập nêu ra, tự xây dựng một distributed cache, thay vì sữ
   dụng những service sẵn có như redis, tôi đã tự xây dựng một caching
   distributed system.
 - Thông qua TCP protocol, các server client (web services, apps...) có
   thể giao tiếp với CachingDistributedSystem.
 - CachingDistributedSystem có thể deploy dưới dạng windows service.
 - Hiện tại chưa support các kiểu dữ liệu khác ngoài String. 
 - Và CachingDistributedSystem sử dụng Inprogress để làm storage.
 **- CachingDistributedSystem  lấy ý tưởng từ Redis để xây dựng, tuy nhiên đây chỉ là demo, còn rất rất nhiều điểm cần cải thiện.**

# Publish this application as a local machine service

## 1. Overview:

Các service client kết nối với CacheSystem thông qua CacheFramework 
Bằng cách [services.AddCachingFramework();] trong Startup.cs


## 2. How to run the app

Chạy đồng thời CachingDistributedSystem và Các Client.
CachingDistributedSystem  sử dung TcpClient để listerning các message từ client
Hiện tại đã cấu hình run with multiple app, cho nên chỉ cần nhấn F5

## 3. CachingDistributedSystem protocol description
- Về cơ bản các service giao tiếp với nhau thông qua message, hiện tại thì chưa build được định dạng cụ thể cho message bytes[].

	Định dạng message OK "+" (Ex: "+OK ")
	Định dạng message lỗi "-" (Ex: "-Error message")
- 

###  Vì làm trong thời gian ngắn, kiến thức cũng hạn chế nên còn nhiều vấn đề, vui lòng cho tôi các feedbacks để cải thiện.
Thank you very much.


