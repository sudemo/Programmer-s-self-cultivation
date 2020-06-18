from django.shortcuts import render

# Create your views here.
from django.shortcuts import render,get_object_or_404
from blog.models import Blog,Book
from django.http import HttpResponse, Http404
from django.template import loader

def index(arg):
    # blog_content = Blog.objects.all()
    blog_content_list = Blog.objects.order_by('creat_date')[:]
    # print(blog_content_list)
    # template = loader.get_template('index.html')
    context = {
            'blog_content_list' :blog_content_list,
        }
    #
    # return HttpResponse(template.render(context))
    # return render('index.html',{'blog_content_list' :blog_content_list})
    # blog =blogcontent.first()
    # content = blog.content
    # return HttpResponse(blogcontent)
    # render()的作用是将数据渲染到指定的模板，第一个参数必须是request，
    # 第二个参数是模板的位置，第三个参数是要传递到模板的数据，这些数据是字典形式的。
    return render(arg, 'index.html', {'blog_list': blog_content_list})  # 返回index.html,blog_list 是给前端的变量名
    # return HttpResponse('1')
def blog_index(arg):
    article_name = get_object_or_404(Blog,id=1)

    sss = 'hello neo'
    return render(arg,"bdetail.html",{"string1":sss})
    # return  render(arg, "bdetail.html", {"article": article_name})


def detail(req,article_id):
    #
    try:
        article = Blog.objects.get(id=article_id)
        # article =get_object_or_404(Blog, id=article_id)
        print('ekere')
        print(article)
    # except Blog.DoesNotExist:
    except Exception as ex:
        print(ex,'1')
        raise Http404("source does not exist")
    # content = Blog
    return render(req, "bdetail.html",{"article": article})
    # return HttpResponse('1212')


def  book_name(req):
    book = Book.objects.all()
    return HttpResponse('1')