//
//  ViewController.swift
//  lolStalker
//
//  Created by Muhand Jumah on 5/31/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import UIKit

class ViewController: UIViewController {
    ////////////////////////////////////
    //            Controls
    ////////////////////////////////////
    let loginView: LoginForm = {
        let view = LoginForm()
        return view
    }()
    
    
    ////////// END OF CONTROLS /////////
    override func viewDidLoad() {
        super.viewDidLoad()
        setupView()
        setupSubViews()
        setupConstraints()
        setupMargins()
    }
    
    func setupView() {
        view.backgroundColor = UIColor(hex: "#010A13")
    }
    
    func setupSubViews() {
        view.addSubview(loginView)
        hideKeyboardWhenTappedAround()
//        view.addSubview(logo)
//        view.addSubview(emailField)
    }
    
    func setupConstraints() {
        // 68.3658170915 came from the reference design on Adobe xd
        // Took the height on Adobe XD and figured it's percentage to the adobe XD height
        // and thats where 68.3658170915 came from
        loginView.translatesAutoresizingMaskIntoConstraints = false
        loginView.centerXAnchor.constraint(equalTo: self.view.centerXAnchor).isActive = true
        loginView.centerYAnchor.constraint(equalTo: self.view.centerYAnchor).isActive = true
//        loginView.heightAnchor.constraint(equalTo: self.view.heightAnchor, multiplier: 0.7).isActive = true
        loginView.heightAnchor.constraint(equalToConstant: Helper.getHeightOf(xdHeight: 456, referenceHeight: nil, originalHeight: nil)).isActive = true
        loginView.widthAnchor.constraint(equalTo: self.view.widthAnchor, constant:-(Helper.getWidthOf(xdWidth: 64, referenceWidth: nil, originalWidth: nil))).isActive = true
        
//                view.addConstraintsWithFormat(format: "H:|[v0]|", views: loginView)
//                view.addConstraintsWithFormat(format: "V:|[v0]|", views: loginView)
//        view.addConstraintsWithFormat(format: "H:|[v0]|", views: loginView)
//        view.addConstraintsWithFormat(format: "V:[v0]", views: emailField)
    }
    
    func setupMargins() {
        self.loginView.center = self.view.center
//        self.logo.center.x = self.view.center.x
//        self.logo.center.y = ((self.view.frame.height * 25) / 100)
//        self.emailField.center.y = ((self.view.frame.height * 50) / 100)
    }
    
    override func viewWillTransition(to size: CGSize, with coordinator: UIViewControllerTransitionCoordinator) {
        super.viewWillTransition(to: size, with: coordinator)
        view.setNeedsDisplay()
    }
}

