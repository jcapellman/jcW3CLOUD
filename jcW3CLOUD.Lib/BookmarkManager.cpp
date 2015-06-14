#include "BookmarkManager.h"

BookmarkManager::BookmarkManager(string fileName) {
	FileReader fr;

	this->_bookmarks = fr.GetVector(fileName, "||");
}

BookmarkManager::BookmarkManager() : BookmarkManager(DEFAULT_BOOKMARK_FILENAME) { }

bool BookmarkManager::AddBookmark(string description, string url) {
	BookmarkItem item = BookmarkItem(description, url);

	vector<BookmarkItem>::iterator it;

	it = this->_bookmarks.begin();

	this->_bookmarks.insert(it, item);

	return true;
}

bool BookmarkManager::RemoveBook(int id) {
	this->_bookmarks.erase(this->_bookmarks.begin() + id);

	return true;
}

vector<BookmarkItem> BookmarkManager::GetAll() {
	return this->_bookmarks;
}
