from rest_framework import permissions

class IsAnOwnerOrReadOnly(permissions.BasePermission):
    def has_object_permission(self, request, view, obj):
        if request.method in permissions.SAFE_METHODS:
            return True

        return (obj.owners.filter(username=request.user.username).count() > 0)