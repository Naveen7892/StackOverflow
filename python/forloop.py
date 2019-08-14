@app.route("/teams/<int:idtofind>", methods=['GET'])
def findbyID(idtofind=None):
    global teamlist

    for i in teamlist:
        for attr, value in i.__dict__.items():
            print(attr, value)
    
    for i in teamlist:
        if i.id == idtofind:
            return i.__dict__

class MyClass(object):
    class_var = 1
    name = ''
    def __init__(self, i_var, name_var):
        self.id = i_var
        self.name = name_var

teamlist = [];
teamlist.append(MyClass(1, 'a'))
teamlist.append(MyClass(2, 'b'))

print(MyClass.__dict__)
print(teamlist[0].__dict__)

print('OUTPUT:')
print(findbyID(1));
print(findbyID(2));
print(findbyID(3));
